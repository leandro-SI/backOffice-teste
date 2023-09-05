import { Pessoa } from "./Pessoa";

export interface Departamento {
  id: number,
  nome: string,
  pessoa: Pessoa,
  dataCadastro: Date
}
