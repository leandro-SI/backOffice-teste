import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PessoasComponent } from './components/pessoas/pessoas.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PessoasNovoComponent } from './components/pessoas/pessoas-novo/pessoas-novo.component';


const routes: Routes = [
  {
    path: 'pessoas', component: PessoasComponent,

  },
  { path: 'pessoas/novo', component: PessoasNovoComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
