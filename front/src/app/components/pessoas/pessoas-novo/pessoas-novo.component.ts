import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TipoPessoa } from './../../../models/TipoPessoa';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { TipoPerfil } from 'src/app/models/TipoPerfil';
import { Qualificacao } from 'src/app/models/Qualificacao';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import Swal from 'sweetalert2/dist/sweetalert2.js';
import { Pessoa } from './../../../models/Pessoa';
import { PessoaDTO } from 'src/app/models/PessoaDTO';
import { TipoPessoaDTO } from 'src/app/models/TipoPessoaDTO';
import { EnderecoDTO } from 'src/app/models/EnderecoDTO';
import { QualificacaoDTO } from 'src/app/models/QualificacaoDTO';


@Component({
  selector: 'app-pessoas-novo',
  templateUrl: './pessoas-novo.component.html',
  styleUrls: ['./pessoas-novo.component.scss']
})
export class PessoasNovoComponent implements OnInit {

  form: FormGroup;

  mascaraCpfCnpj: string = '';

  modalRef?: BsModalRef;
  message?: string;

  selectedTipoPessoa: string;
  public tiposPessoa: TipoPessoa[] = [];
  public tiposPerfil: TipoPerfil[] = [];
  public qualificacoes: Qualificacao[] = [];

  private nome: string;
  private documento: string;
  private apelido: string;
  private tipoPessoaId: number;
  private cep: string;
  private rua: string;
  private cidade: string;
  private uf: string;
  public pessoa = new PessoaDTO();


  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private router: Router) { }

  ngOnInit() {
    this.spinner.show();
    this.getTiposPessoa();
    this.getQualificacoe();
    //this.getTiposPerfil();
    this.validation();
  }

  public validation(): void {
    this.form = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      documento: ['', Validators.required],
      apelido: ['', Validators.required],
      tipoPessoa: ['', [Validators.required]],
      cep: ['', Validators.required],
      rua: ['', Validators.required],
      cidade: ['', Validators.required],
      uf: ['', Validators.required],
      qualificacao: ['', Validators.required],
      // departamento: ['', Validators.required]
    });
  }

  public salvarPessoa(): void{

    Swal.fire({
      title: 'Salvar Pessoa',
      text: 'Deseja realmente salvar o novo registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'SIM!',
      cancelButtonText: 'CANCELAR'
    }).then((result) => {
      if (result.value) {

        this.pessoa.endereco = new EnderecoDTO();

        this.pessoa.nome = this.form.controls.nome.value;
        this.pessoa.documento = this.form.controls.documento.value;
        this.pessoa.apelido = this.form.controls.apelido.value;
        this.pessoa.tipoPessoaId = this.form.controls.tipoPessoa.value;
        this.pessoa.endereco.cep = this.form.controls.cep.value;
        this.pessoa.endereco.rua = this.form.controls.rua.value;
        this.pessoa.endereco.cidade = this.form.controls.cidade.value;
        this.pessoa.endereco.uf = this.form.controls.uf.value;
        this.pessoa.qualificacaoId = this.form.controls.qualificacao.value;

        this.pessoaService.salvarPessoa(this.pessoa).subscribe({
          next: (result: any) => {

            console.log('RESULT: ', result);
            if(result) {

              Swal.fire(
                'Salvo!',
                'Registro salvo com sucesso.',
                'success'
              )

              this.router.navigate(['/pessoas']);
            }
          },
          error: (error: string) => {
            this.spinner.hide();
            this.showError('Erro ao salvar o registros.', 'Erro!')
          },
          complete: () => {
            this.spinner.hide();
          }
        })


      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your imaginary file is safe :)',
          'error'
        )
      }
    })
  }


  atualizarMascara() {
    const valor = this.form.controls.documento.value.replace(/\D/g, '');

    if (this.form.controls.tipoPessoa.value == 1) {
      this.mascaraCpfCnpj = '000.000.000-00'; // CPF
    } else {
      this.mascaraCpfCnpj = '00.000.000/0000-00'; // CNPJ
    }
  }

  public getTiposPessoa(): void {

    this.pessoaService.getTiposPessoa().subscribe({
      next: (tipos: TipoPessoa[]) => {
        this.tiposPessoa = tipos;
      },
      error: (error: string) => {
        this.spinner.hide();
        this.showError('Erro ao carregar os registros.', 'Erro!')
      },
      complete: () => {
        this.spinner.hide();
      }
    })
  }

  public getTiposPerfil(): void {

    this.pessoaService.getTiposPerfil().subscribe({
      next: (tipos: TipoPerfil[]) => {
        this.tiposPerfil = tipos;
      },
      error: (error: string) => {
        this.spinner.hide();
        this.showError('Erro ao carregar os registros.', 'Erro!')
      },
      complete: () => {
        this.spinner.hide();
      }
    })
  }

  public getQualificacoe(): void {

    this.pessoaService.getQualificacoes().subscribe({
      next: (q: Qualificacao[]) => {
        this.qualificacoes = q;
      },
      error: (error: string) => {
        this.spinner.hide();
        this.showError('Erro ao carregar os registros.', 'Erro!')
      },
      complete: () => {
        this.spinner.hide();
      }
    })
  }

  public consultaCep(valor, form) {
    this.pessoaService.buscarCep(valor).subscribe((dados) => this.populaForm(dados, form));
  }

  public populaForm(dados, form) {

    if (dados.erro === true) {
      this.erroaEndereco();
      return;
    }

    this.form.controls.rua.setValue(dados.logradouro);
    this.form.controls.cidade.setValue(dados.localidade);
    this.form.controls.uf.setValue(dados.uf);

  }

  erroaEndereco()
  {
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: 'Endereço não encontrado!',
      footer: 'Insira um CEP válido.'
    })
  }

  reseteForm(): void {
    this.form.reset();
  }

  cssValidator(campoForm: FormGroup): any {
    return {'is-invalid': campoForm.errors && campoForm.touched};
  }

  showSuccess(msg, title) {
    this.toastr.success(msg, title);
  }

  showError(msg, title) {
    this.toastr.error(msg, title);
  }

}
