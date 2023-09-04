import { TipoPerfil } from './TipoPerfil';

export interface Usuario {
  id: number,
  login: string,
  email: string,
  tipoPerfil: TipoPerfil
}
