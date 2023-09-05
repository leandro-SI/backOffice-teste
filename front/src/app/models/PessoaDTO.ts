import { DepartamentoDTO } from "./DepartamentoDTO";
import { EnderecoDTO } from "./EnderecoDTO"
import { QualificacaoDTO } from "./QualificacaoDTO"
import { TipoPessoaDTO } from "./TipoPessoaDTO"


export class PessoaDTO {
  id: number;
  nome: string;
  documento: string;
  apelido: string;
  tipoPessoa: TipoPessoaDTO;
  tipoPessoaId: number;
  endereco: EnderecoDTO;
  enderecoId: number;
  qualificacao: QualificacaoDTO;
  qualificacaoId: number;
  departamentos: DepartamentoDTO[];
}
