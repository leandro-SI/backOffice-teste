using BackOffice.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackOffice.Aplicacao.DTOs
{
    public class DepartamentoDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O Nome é Requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
        public long PessoaId { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public Pessoa Pessoa { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
