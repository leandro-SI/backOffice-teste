using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Interfaces
{
    public interface IPessoaRepository
    {
        Task<IEnumerable<Pessoa>> ListarPessoas();
        Task<Pessoa> BuscarPessoaPorId(long id);
        Task<Pessoa> CadastrarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoa(Pessoa pessoa);
        Task<Pessoa> RemoverPessoa(Pessoa pessoa);
    }
}
