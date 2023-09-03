using AutoMapper;
using BackOffice.Aplicacao.DTOs;
using BackOffice.Aplicacao.Services.Interfaces;
using BackOffice.Dominio.Entities;
using BackOffice.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Aplicacao.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly IMapper _mapper;

        public DepartamentoService(IDepartamentoRepository departamentoRepository, IMapper mapper)
        {
            _departamentoRepository = departamentoRepository ?? throw new ArgumentNullException(nameof(departamentoRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartamentoDTO>> ListarDepartamentos()
        {
            var departamentos = await _departamentoRepository.ListarDepartamentos();

            return _mapper.Map<IEnumerable<DepartamentoDTO>>(departamentos);
        }

        public async Task<DepartamentoDTO> BuscarDepartamento(long id)
        {
            var departamento = await _departamentoRepository.BuscarDepartamentoPorId(id);

            return _mapper.Map<DepartamentoDTO>(departamento);
        }

        public async Task AtualizarDepartamento(DepartamentoDTO departamentoDto)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDto);

            await _departamentoRepository.AtualizarDepartamento(departamento);
        }

        public async Task CadastrarDepartamento(DepartamentoDTO departamentoDto)
        {
            var departamento = _mapper.Map<Departamento>(departamentoDto);

            await _departamentoRepository.AtualizarDepartamento(departamento);
        }

        public async Task RemoverDepartamento(long id)
        {
            var departamento = await _departamentoRepository.BuscarDepartamentoPorId(id);

            await _departamentoRepository.RemoverDepartamento(departamento);
        }
    }
}
