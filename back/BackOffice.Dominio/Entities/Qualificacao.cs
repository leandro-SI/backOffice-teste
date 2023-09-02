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


        public Qualificacao(string descricao)
        {
            ValidaQualificacao(descricao);
        }

        public Qualificacao(long id, string descricao)
        {
            ValidaQualificacao(descricao);
            Id = id;
        }

        private void ValidaQualificacao(string descricao)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descricao inválido, Descricao é requerido.");

            DominioExceptionValidation.When(descricao.Length < 3,
                "Descricao inválido, mínimo de 3 caracteres é requerido.");
        }
    }
}
