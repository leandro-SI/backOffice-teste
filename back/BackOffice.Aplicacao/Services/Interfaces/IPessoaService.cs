using BackOffice.Aplicacao.DTOs;
using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Aplicacao.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<IEnumerable<PessoaDTO>> ListarPessoas();
        Task<PessoaDTO> BuscarPessoa(long id);
        Task CadastrarPessoa(PessoaDTO pessoaDto);
        Task AtualizarPessoa(PessoaDTO pessoaDto);
        Task RemoverPessoa(long id);
        Task<IEnumerable<TipoPessoaDTO>> ListarTiposPessoa();
        Task<IEnumerable<TipoPerfilDTO>> ListarTiposPerfil();
        Task<IEnumerable<QualificacaoDTO>> ListarQualificacoes();
    }
}
