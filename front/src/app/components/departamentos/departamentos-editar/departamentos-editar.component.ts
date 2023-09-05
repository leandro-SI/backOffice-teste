import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DepartamentoDTO } from 'src/app/models/DepartamentoDTO';
import { Pessoa } from 'src/app/models/Pessoa';
import { PessoaDTO } from 'src/app/models/PessoaDTO';
import { DepartamentoService } from 'src/app/services/departamentos/departamentos.service';
import { PessoaService } from 'src/app/services/pessoas/pessoa.service';
import Swal from 'sweetalert2/dist/sweetalert2.js';


@Component({
  selector: 'app-departamentos-editar',
  templateUrl: './departamentos-editar.component.html',
  styleUrls: ['./departamentos-editar.component.sass']
})
export class DepartamentosEditarComponent implements OnInit {

  form: FormGroup;
  modalRef?: BsModalRef;
  message?: string;

  public selectedPessoa: Pessoa;
  public pessoas: PessoaDTO[] = [];
  public departamentoForm: DepartamentoDTO;
  public idDepartamento: number;

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder,
    private pessoaService: PessoaService,
    private departamentoService: DepartamentoService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private modalService: BsModalService,
    private route: ActivatedRoute,
    private router: Router) {

    }

    ngOnInit() {
      this.route.params.subscribe(params => {
        this.idDepartamento = params['id'];
        console.log('ID: ', this.idDepartamento);
      });

      this.getDepartamento();
      this.getPessoas();
    }

  public getDepartamento(): void {

    this.departamentoService.getDepartamento(this.idDepartamento).subscribe({
      next: (de: DepartamentoDTO) => {
        this.departamentoForm = de;

        this.form = this.formBuilder.group({
          id: [this.departamentoForm.id],
          nome: [this.departamentoForm.nome, [Validators.required]],
          pessoa: [this.departamentoForm.pessoa, [Validators.required]],
          pessoaId: [this.departamentoForm.pessoa.id, [Validators.required]],
        });

        console.log('DEPARTAMENTO FORM: ', this.departamentoForm)

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

  public getPessoas(): void {

    this.pessoaService.getPessoasDTO().subscribe({
      next: (pessoas: PessoaDTO[]) => {
        this.pessoas = pessoas;
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

  public atualizarDepartamento() : void {
    Swal.fire({
      title: 'Atualizar Departamento',
      text: 'Deseja realmente atualizar o registro?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'SIM!',
      cancelButtonText: 'CANCELAR'
    }).then((result) => {
      if (result.value) {

        this.departamentoForm.id = this.form.controls.id.value;
        this.departamentoForm.nome = this.form.controls.nome.value;
        this.departamentoForm.pessoaId = this.form.controls.pessoaId.value;
        this.departamentoForm.pessoa = this.pessoas.find(x => x.id == this.departamentoForm.pessoaId);

        //this.form.controls.pessoaId.value;

        this.departamentoService.atualizarDepartamento(this.idDepartamento, this.departamentoForm).subscribe({
          next: (result: any) => {

            console.log('RESULT: ', result);
            if(result) {

              Swal.fire(
                'Salvo!',
                'Registro atualizado com sucesso.',
                'success'
              )

              this.router.navigate(['/departamentos']);
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
