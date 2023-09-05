import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PessoasNovoComponent } from './components/pessoas/pessoas-novo/pessoas-novo.component';
import { PessoasEditarComponent } from './components/pessoas/pessoas-editar/pessoas-editar.component';
import { DepartamentosComponent } from './components/departamentos/departamentos.component';
import { DepartamentosNovoComponent } from './components/departamentos/departamentos-novo/departamentos-novo.component';
import { DepartamentosEditarComponent } from './components/departamentos/departamentos-editar/departamentos-editar.component';


const routes: Routes = [
  { path: 'pessoas', component: PessoasComponent },
  { path: 'pessoas/novo', component: PessoasNovoComponent },
  { path: 'pessoas/editar/:id', component: PessoasEditarComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'departamentos', component: DepartamentosComponent },
  { path: 'departamentos/novo', component: DepartamentosNovoComponent },
  { path: 'departamentos/editar/:id', component: DepartamentosEditarComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
