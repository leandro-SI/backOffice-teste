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
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository ?? throw new ArgumentNullException(nameof(pessoaRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PessoaDTO>> ListarPessoas()
        {
            var pessoas = await _pessoaRepository.ListarPessoas();

            return _mapper.Map<IEnumerable<PessoaDTO>>(pessoas);
        }

        public async Task<PessoaDTO> BuscarPessoa(long id)
        {
            var pessoa = await _pessoaRepository.BuscarPessoaPorId(id);

            return _mapper.Map<PessoaDTO>(pessoa);
        }

        public async Task AtualizarPessoa(PessoaDTO pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);

            await _pessoaRepository.AtualizarPessoa(pessoa);
        }

        public async Task CadastrarPessoa(PessoaDTO pessoaDto)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaDto);

            await _pessoaRepository.CadastrarPessoa(pessoa);
        }

        public async Task RemoverPessoa(long id)
        {
            var pessoa = await _pessoaRepository.BuscarPessoaPorId(id);

            await _pessoaRepository.RemoverPessoa(pessoa);
        }

        public async Task<IEnumerable<TipoPessoaDTO>> ListarTiposPessoa()
        {
            var tiposPessoa = await _pessoaRepository.ListarTiposPessoa();

            return _mapper.Map<IEnumerable<TipoPessoaDTO>>(tiposPessoa);
        }

        public async Task<IEnumerable<TipoPerfilDTO>> ListarTiposPerfil()
        {
            var tiposPerfil = await _pessoaRepository.ListarTiposPerfil();

            return _mapper.Map<IEnumerable<TipoPerfilDTO>>(tiposPerfil);
        }

        public async Task<IEnumerable<QualificacaoDTO>> ListarQualificacoes()
        {
            var qualificacoes = await _pessoaRepository.ListarQualificacoes();

            return _mapper.Map<IEnumerable<QualificacaoDTO>>(qualificacoes);
        }
    }
}
