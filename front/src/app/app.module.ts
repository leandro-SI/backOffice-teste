import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PessoaService } from './services/pessoas/pessoa.service';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PessoasNovoComponent } from './components/pessoas/pessoas-novo/pessoas-novo.component';
import { NgxMaskModule } from 'ngx-mask';
import { PessoasEditarComponent } from './components/pessoas/pessoas-editar/pessoas-editar.component';
import { DepartamentosComponent } from './components/departamentos/departamentos.component';
import { DepartamentosNovoComponent } from './components/departamentos/departamentos-novo/departamentos-novo.component';
import { DepartamentosEditarComponent } from './components/departamentos/departamentos-editar/departamentos-editar.component';

@NgModule({
  declarations: [
    AppComponent,
    PessoasComponent,
    PessoasNovoComponent,
    PessoasEditarComponent,
    NavComponent,
    DashboardComponent,
    DateTimeFormatPipe,
    DepartamentosComponent,
    DepartamentosNovoComponent,
    DepartamentosEditarComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule,
    NgxMaskModule.forRoot()
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    PessoaService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
