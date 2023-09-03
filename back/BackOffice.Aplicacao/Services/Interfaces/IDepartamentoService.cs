using BackOffice.Aplicacao.DTOs;
using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Aplicacao.Services.Interfaces
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoDTO>> ListarDepartamentos();
        Task<DepartamentoDTO> BuscarDepartamento(long id);
        Task CadastrarDepartamento(DepartamentoDTO departamentoDto);
        Task AtualizarDepartamento(DepartamentoDTO departamentoDto);
        Task RemoverDepartamento(long id);
    }
}
