import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from 'src/app/models/Pessoa';

@Injectable(
  {providedIn: 'root'}
)
export class PessoaService {

  baseURL = 'https://localhost:7237/api/pessoas/';

  constructor(private http: HttpClient) { }

  getPessoas() : Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.baseURL + "ListarPessoas");
  }

}
