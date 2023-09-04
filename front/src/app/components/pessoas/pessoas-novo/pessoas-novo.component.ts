import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TipoPessoa } from './../../../models/TipoPessoa';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router } from '@angular/router';
import { TipoPerfil } from 'src/app/models/TipoPerfil';
import { Qualificacao } from 'src/app/models/Qualificacao';

@Component({
  selector: 'app-pessoas-novo',
  templateUrl: './pessoas-novo.component.html',
  styleUrls: ['./pessoas-novo.component.scss']
})
export class PessoasNovoComponent implements OnInit {

  form: FormGroup;

  selectedTipoPessoa: string;
  public tiposPessoa: TipoPessoa[] = [];
  public tiposPerfil: TipoPerfil[] = [];
  public qualificacoes: Qualificacao[] = [];

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
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

    console.log('DADOS: ', dados)

    this.form.controls.rua.setValue(dados.logradouro);

    // form.setValue({
    //   cep: dados.cep,
    //   rua: dados.logradouro,
    //   bairro: dados.bairro,
    //   cidade: dados.localidade,
    //   uf: dados.uf
    // })
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
