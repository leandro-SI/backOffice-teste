import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DepartamentoDTO } from 'src/app/models/DepartamentoDTO';
import { Pessoa } from 'src/app/models/Pessoa';
import { PessoaDTO } from 'src/app/models/PessoaDTO';

@Injectable(
  {providedIn: 'root'}
)
export class DepartamentoService {

  baseURL = 'https://localhost:7237/api/departamentos/';

  constructor(private http: HttpClient) { }

  getDepartamentos() : Observable<DepartamentoDTO[]> {
    return this.http.get<DepartamentoDTO[]>(this.baseURL + "ListarDepartamentos");
  }

  salvarDepartamento(departamentoDTO: DepartamentoDTO) {

    const request = {
      departamentoDTO: departamentoDTO,
    }

    return this.http.post<DepartamentoDTO>(this.baseURL + "CadastrarDepartamento", request.departamentoDTO);
  }

  atualizarDepartamento(id: number, departamentoDTO: DepartamentoDTO) {

    const request = {
      departamentoDTO: departamentoDTO,
    }

    return this.http.put<DepartamentoDTO>(this.baseURL + "AtualizarDepartamento/" + id, request.departamentoDTO);
  }

  getDepartamento(id: number) : Observable<DepartamentoDTO> {
    return this.http.get<DepartamentoDTO>(this.baseURL + "BuscarDepartamento?id=" + id);
  }

}
