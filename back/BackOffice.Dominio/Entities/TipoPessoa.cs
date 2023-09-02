using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class TipoPessoa : BaseEntity
    {
        public string Descricao { get; private set; }

        public TipoPessoa(string descricao)
        {
            ValidaTipoPessoa(descricao);
        }

        public TipoPessoa(long id, string descricao)
        {
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidaTipoPessoa(descricao);
        }


        private void ValidaTipoPessoa(string descricao)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descricao inválido, Descricao é requerido.");

            DominioExceptionValidation.When(descricao.Length < 3,
                "Descricao inválido, mínimo de 3 caracteres é requerido.");
        }
    }
}
