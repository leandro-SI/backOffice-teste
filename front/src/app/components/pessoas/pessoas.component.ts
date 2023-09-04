import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Pessoa } from 'src/app/models/Pessoa';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';

@Component({
  selector: 'app-pessoas',
  templateUrl: './pessoas.component.html',
  styleUrls: ['./pessoas.component.scss']
})
export class PessoasComponent implements OnInit {

  public titulo = 'Pessoas';

  modalRef?: BsModalRef;
  message?: string;

  public pessoas: Pessoa[] = [];
  public pessoasFiltradas: Pessoa[] = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.pessoasFiltradas = this._filtroLista ? this.filtrarPessoas(this.filtroLista) : this.pessoas;
  }

  public filtrarPessoas(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pessoas.filter(
      pessoa => pessoa.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      pessoa.apelido.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  constructor(private pessoaService: PessoaService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

    ngOnInit(): void {
      this.spinner.show();
      this.getPessoas()
    }

    public getPessoas(): void {

      this.pessoaService.getPessoas().subscribe({
        next: (p: Pessoa[]) => {
          this.pessoas = p;
          this.pessoasFiltradas = p;

          console.log('PESSOAS: ', this.pessoas)
          console.log('TIPO PESSOA: ', this.pessoas[0].tipoPessoa)
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

    public detalhePessoa(id: number) {

    }

    openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    decline(): void {
      this.message = 'Declined!';
      this.modalRef?.hide();
    }

    confirm(): void {
      this.message = 'Confirmed!';
      this.modalRef?.hide();
      this.showSuccess('O registro foi deletado com sucesso.', 'Deletado!');
    }

    showSuccess(msg, title) {
      this.toastr.success(msg, title);
    }

    showError(msg, title) {
      this.toastr.error(msg, title);
    }

}
