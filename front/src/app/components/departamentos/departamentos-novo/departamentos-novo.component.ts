import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DepartamentoDTO } from 'src/app/models/DepartamentoDTO';
import { Pessoa } from 'src/app/models/Pessoa';
import { DepartamentoService } from 'src/app/services/departamentos/departamentos.service';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';

@Component({
  selector: 'app-departamentos-novo',
  templateUrl: './departamentos-novo.component.html',
  styleUrls: ['./departamentos-novo.component.sass']
})
export class DepartamentosNovoComponent implements OnInit {

  form: FormGroup;
  modalRef?: BsModalRef;
  message?: string;

  selectedPessoa: string;
  public pessoas: Pessoa[] = [];

  private nome: string;
  private pessoaId: number;
  private apelido: string;
  public departamento = new DepartamentoDTO();

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private departamentoService: DepartamentoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private router: Router) { }

    ngOnInit() {
      this.spinner.show();
      this.getPessoas();
      this.validation();
    }

    public validation(): void {
      this.form = this.formBuilder.group({
        nome: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
        pessoa: ['', Validators.required]
      });
    }

    public salvarDepartamento(): void{

      Swal.fire({
        title: 'Salvar Departamento',
        text: 'Deseja realmente salvar o novo registro?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'SIM!',
        cancelButtonText: 'CANCELAR'
      }).then((result) => {
        if (result.value) {

          this.departamento.nome = this.form.controls.nome.value;
          this.departamento.pessoaId = this.form.controls.pessoa.value;

          this.departamentoService.salvarDepartamento(this.departamento).subscribe({
            next: (result: any) => {

              if(result) {

                Swal.fire(
                  'Salvo!',
                  'Registro salvo com sucesso.',
                  'success'
                )

                this.router.navigate(['/departamentos']);
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

    public getPessoas(): void {

      this.pessoaService.getPessoas().subscribe({
        next: (p: Pessoa[]) => {
          this.pessoas = p;
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
