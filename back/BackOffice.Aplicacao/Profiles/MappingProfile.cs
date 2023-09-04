using AutoMapper;
using BackOffice.Aplicacao.DTOs;
using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Aplicacao.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<TipoPessoa, TipoPessoaDTO>().ReverseMap();
            CreateMap<TipoPerfil, TipoPerfilDTO>().ReverseMap();
            CreateMap<Qualificacao, QualificacaoDTO>().ReverseMap();
        }
    }
}
