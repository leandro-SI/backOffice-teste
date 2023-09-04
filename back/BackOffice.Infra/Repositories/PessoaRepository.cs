using BackOffice.Dominio.Entities;
using BackOffice.Dominio.Interfaces;
using BackOffice.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BackOfficeContext _pessoaContext;

        public PessoaRepository(BackOfficeContext context)
        {
            _pessoaContext = context;
        }

        public async Task<Pessoa> CadastrarPessoa(Pessoa pessoa)
        {
            _pessoaContext.Add(pessoa);
            await _pessoaContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> BuscarPessoaPorId(long id)
        {
            return await _pessoaContext.Pessoas.Include(p => p.Endereco)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pessoa>> ListarPessoas()
        {
            return await _pessoaContext.Pessoas.Include(p => p.TipoPessoa).ToListAsync();
        }

        public async Task<Pessoa> AtualizarPessoa(Pessoa pessoa)
        {
            _pessoaContext.Pessoas.Update(pessoa);
            await _pessoaContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<Pessoa> RemoverPessoa(Pessoa pessoa)
        {
            _pessoaContext.Pessoas.Remove(pessoa);
            await _pessoaContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<IEnumerable<TipoPessoa>> ListarTiposPessoa()
        {
            return await _pessoaContext.TipoPessoas.ToListAsync();
        }

        public async Task<IEnumerable<TipoPerfil>> ListarTiposPerfil()
        {
            return await _pessoaContext.TipoPerfis.ToListAsync();
        }

        public async Task<IEnumerable<Qualificacao>> ListarQualificacoes()
        {
            return await _pessoaContext.Qualificacoes.ToListAsync();
        }
    }
}
