using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class Qualificacao : BaseEntity
    {
        public string Descricao { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }


        public Qualificacao(string descricao)
        {
            ValidaQualificacao(descricao);
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Qualificacao(long id, string descricao)
        {
            ValidaQualificacao(descricao);
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void Update(string descricao)
        {
            ValidaQualificacao(descricao);
            DataAtualizacao = DateTime.Now;
        }

        private void ValidaQualificacao(string descricao)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descricao inválido, Descricao é requerido.");

            DominioExceptionValidation.When(descricao.Length < 3,
                "Descricao inválido, mínimo de 3 caracteres é requerido.");

            Descricao = descricao;
        }
    }
}
