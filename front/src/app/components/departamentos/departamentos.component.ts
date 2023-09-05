import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Departamento } from 'src/app/models/Departamento';
import { DepartamentoDTO } from 'src/app/models/DepartamentoDTO';
import { DepartamentoService } from 'src/app/services/departamentos/departamentos.service';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';

@Component({
  selector: 'app-departamentos',
  templateUrl: './departamentos.component.html',
  styleUrls: ['./departamentos.component.scss']
})
export class DepartamentosComponent implements OnInit {

  public titulo = 'Departamentos';

  modalRef?: BsModalRef;
  message?: string;

  public departamentos: DepartamentoDTO[] = [];
  public departamentosFiltrados: DepartamentoDTO[] = [];
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.departamentosFiltrados = this._filtroLista ? this.filtrarDepartamentos(this.filtroLista) : this.departamentos;
  }

  public filtrarDepartamentos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.departamentos.filter(
      departamento => departamento.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }


  constructor(private pessoaService: PessoaService,
    private departamentoService: DepartamentoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) { }

    ngOnInit(): void {
      this.spinner.show();
      this.getDepartamentos()
    }

    public getDepartamentos(): void {

      this.departamentoService.getDepartamentos().subscribe({
        next: (de: DepartamentoDTO[]) => {
          this.departamentos = de;
          this.departamentosFiltrados = de;

          console.log('DePARTAMENTOS: ', this.departamentos)
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

    openModal(template: TemplateRef<any>) {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    decline(): void {
      this.message = 'Declined!';
      this.modalRef?.hide();
    }

    showSuccess(msg, title) {
      this.toastr.success(msg, title);
    }

    showError(msg, title) {
      this.toastr.error(msg, title);
    }

}
