import { PessoaDTO } from "./PessoaDTO";

export class DepartamentoDTO {
  id: number;
  nome: string;
  pessoa: PessoaDTO;
  pessoaId: number;
  dataCadastro: Date;
}
