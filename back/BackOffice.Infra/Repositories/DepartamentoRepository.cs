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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly BackOfficeContext _departamentoContext;

        public DepartamentoRepository(BackOfficeContext context)
        {
            _departamentoContext = context;
        }

        public async Task<Departamento> CadastrarDepartamento(Departamento departamento)
        {
            _departamentoContext.Departamentos.Add(departamento);
            await _departamentoContext.SaveChangesAsync();

            return departamento;
        }

        public async Task<Departamento> BuscarDepartamentoPorId(long id)
        {
            return await _departamentoContext.Departamentos.Include(d => d.Pessoa)
                .SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Departamento>> ListarDepartamentos()
        {
            return await _departamentoContext.Departamentos.ToListAsync();
        }

        public async Task<Departamento> AtualizarDepartamento(Departamento departamento)
        {
            _departamentoContext.Departamentos.Update(departamento);
            await _departamentoContext.SaveChangesAsync();

            return departamento;
        }

        public async Task<Departamento> RemoverDepartamento(Departamento departamento)
        {
            _departamentoContext.Departamentos.Remove(departamento);
            await _departamentoContext.SaveChangesAsync();

            return departamento;
        }
    }
}
