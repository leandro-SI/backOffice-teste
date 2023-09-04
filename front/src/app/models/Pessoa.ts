import { Departamento } from "./Departamento";
import { Endereco } from "./Endereco";
import { Qualificacao } from "./Qualificacao";
import { TipoPessoa } from "./TipoPessoa";


export interface Pessoa {
  id: number,
  nome: string,
  documento: string,
  apelido: string,
  tipoPessoa: TipoPessoa,
  endereco: Endereco,
  qualificacao: Qualificacao,
  departamentos: Departamento[],

}
