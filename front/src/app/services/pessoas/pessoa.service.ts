import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from 'src/app/models/Pessoa';
import { PessoaDTO } from 'src/app/models/PessoaDTO';
import { Qualificacao } from 'src/app/models/Qualificacao';
import { TipoPerfil } from 'src/app/models/TipoPerfil';
import { TipoPessoa } from 'src/app/models/TipoPessoa';

@Injectable(
  {providedIn: 'root'}
)
export class PessoaService {

  baseURL = 'https://localhost:7237/api/pessoas/';

  constructor(private http: HttpClient) { }

  getPessoas() : Observable<Pessoa[]> {
    return this.http.get<Pessoa[]>(this.baseURL + "ListarPessoas");
  }


  getTiposPessoa() : Observable<TipoPessoa[]> {
    return this.http.get<TipoPessoa[]>(this.baseURL + "ListarTiposPessoa");
  }

  getTiposPerfil() : Observable<TipoPerfil[]> {
    return this.http.get<TipoPerfil[]>(this.baseURL + "ListarTiposPerfil");
  }

  getQualificacoes() : Observable<Qualificacao[]> {
    return this.http.get<Qualificacao[]>(this.baseURL + "ListarQualificacoes");
  }

  buscarCep(cep: string) {
    return this.http.get(`https://viacep.com.br/ws/${cep}/json/`)
  }

  salvarPessoa(pessoaDTO: PessoaDTO) {

    const request = {
      pessoaDTO: pessoaDTO,
    }

    return this.http.post<PessoaDTO>(this.baseURL + "CadastrarPessoa", request.pessoaDTO);
  }

  atualizarPessoa(id: number, pessoaDTO: PessoaDTO) {

    const request = {
      pessoaDTO: pessoaDTO,
    }

    console.log('ATUALIZA PESSOA DTO: ', pessoaDTO)

    return this.http.put<PessoaDTO>(this.baseURL + "AtualizarPessoa/" + id, request.pessoaDTO);
  }

  getPessoa(id: number) : Observable<PessoaDTO> {
    return this.http.get<PessoaDTO>(this.baseURL + "BuscarPessoa?id=" + id);
  }

}
