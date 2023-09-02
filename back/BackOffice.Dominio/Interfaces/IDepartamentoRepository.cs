using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<IEnumerable<Departamento>> ListarDepartamentos();
        Task<Departamento> BuscarDepartamentoPorId(long id);
        Task<Departamento> CadastrarDepartamento(Departamento departamento);
        Task<Departamento> AtualizarDepartamento(Departamento departamento);
        Task<Departamento> RemoverDepartamento(Departamento departamento);
    }
}
