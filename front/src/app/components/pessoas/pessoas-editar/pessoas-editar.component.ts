import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EnderecoDTO } from 'src/app/models/EnderecoDTO';
import { PessoaDTO } from 'src/app/models/PessoaDTO';
import { Qualificacao } from 'src/app/models/Qualificacao';
import { TipoPerfil } from 'src/app/models/TipoPerfil';
import { TipoPessoa } from 'src/app/models/TipoPessoa';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Component({
  selector: 'app-pessoas-editar',
  templateUrl: './pessoas-editar.component.html',
  styleUrls: ['./pessoas-editar.component.scss']
})
export class PessoasEditarComponent implements OnInit {

  form: FormGroup;

  mascaraCpfCnpj: string = '';

  modalRef?: BsModalRef;
  message?: string;

  selectedTipoPessoa: string;
  public tiposPessoa: TipoPessoa[] = [];
  public tiposPerfil: TipoPerfil[] = [];
  public qualificacoes: Qualificacao[] = [];
  public pessoaForm: PessoaDTO;
  public idPessoa: number;


  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router) {

    }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.idPessoa = params['id'];
      console.log('ID: ', this.idPessoa);
    });

    this.getPessoa();
    this.getQualificacoe();
    this.getTiposPessoa();
  }

  public getPessoa(): void {

    this.pessoaService.getPessoa(this.idPessoa).subscribe({
      next: (p: PessoaDTO) => {
        this.pessoaForm = p;

        this.form = this.formBuilder.group({
          id: [this.pessoaForm.id],
          nome: [this.pessoaForm.nome, [Validators.required]],
          documento: [this.pessoaForm.documento, [Validators.required]],
          apelido: [this.pessoaForm.apelido, [Validators.required]],
          tipoPessoa: [this.pessoaForm.tipoPessoa, [Validators.required]],
          tipoPessoaId: [this.pessoaForm.tipoPessoa.id, [Validators.required]],
          endereco: [this.pessoaForm.endereco, [Validators.required]],
          cep: [this.pessoaForm.endereco.cep, [Validators.required]],
          rua: [this.pessoaForm.endereco.rua, [Validators.required]],
          cidade: [this.pessoaForm.endereco.cidade, [Validators.required]],
          uf: [this.pessoaForm.endereco.uf, [Validators.required]],
          qualificacao: [this.pessoaForm.qualificacao],
          qualificacaoId: [this.pessoaForm.qualificacao.id, [Validators.required]],
        });

        console.log('PESSOA FORM: ', this.pessoaForm)

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

  public atualizarPessoa() : void {
    Swal.fire({
      title: 'Atualizar Pessoa',
      text: 'Deseja realmente atualizar o registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'SIM!',
      cancelButtonText: 'CANCELAR'
    }).then((result) => {
      if (result.value) {

        this.pessoaForm.endereco = new EnderecoDTO();

        this.pessoaForm.id = this.form.controls.id.value;
        this.pessoaForm.nome = this.form.controls.nome.value;
        this.pessoaForm.documento = this.form.controls.documento.value;
        this.pessoaForm.apelido = this.form.controls.apelido.value;
        this.pessoaForm.tipoPessoaId = this.form.controls.tipoPessoaId.value;
        this.pessoaForm.endereco.cep = this.form.controls.cep.value;
        this.pessoaForm.endereco.rua = this.form.controls.rua.value;
        this.pessoaForm.endereco.cidade = this.form.controls.cidade.value;
        this.pessoaForm.endereco.uf = this.form.controls.uf.value;
        this.pessoaForm.qualificacaoId = this.form.controls.qualificacaoId.value;

        this.pessoaService.atualizarPessoa(this.idPessoa, this.pessoaForm).subscribe({
          next: (result: any) => {

            console.log('RESULT: ', result);
            if(result) {

              Swal.fire(
                'Salvo!',
                'Registro atualizado com sucesso.',
                'success'
              )

              this.router.navigate(['/pessoas']);
            }
          },
          error: (error: string) => {
            this.spinner.hide();
            this.showError('Erro ao atualizar o registros.', 'Erro!')
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

  atualizarMascara() {
    const valor = this.form.controls.documento.value.replace(/\D/g, '');

    if (this.form.controls.tipoPessoa.value == 1) {
      this.mascaraCpfCnpj = '000.000.000-00'; // CPF
    } else {
      this.mascaraCpfCnpj = '00.000.000/0000-00'; // CNPJ
    }
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

  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef?.hide();
    this.showSuccess('O registro foi deletado com sucesso.', 'Deletado!');
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
