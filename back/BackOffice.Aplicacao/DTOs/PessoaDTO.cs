using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BackOffice.Dominio.Entities;

namespace BackOffice.Aplicacao.DTOs
{
    public class PessoaDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O Nome é Requerido")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Documento é Requerido")]
        [MinLength(11)]
        [MaxLength(14)]
        [DisplayName("Documento")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O Apelido é Requerido")]
        [MinLength(10)]
        [MaxLength(100)]
        [DisplayName("Apelido")]
        public string Apelido { get; set; }

        public long TipoPessoaId { get; set; }

        //[JsonIgnore]
        //[IgnoreDataMember]
        public TipoPessoaDTO TipoPessoa { get; set; }

        public long EnderecoId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Endereco Endereco { get; set; }

        public long QualificacaoId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Qualificacao Qualificacao { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
