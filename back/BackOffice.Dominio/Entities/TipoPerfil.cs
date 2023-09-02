using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class TipoPerfil : BaseEntity
    {
        public string Descricao { get; private set; }

        public TipoPerfil(string descricao)
        {
            ValidaTipoPerfil(descricao);
        }

        public TipoPerfil(long id, string descricao)
        {
            ValidaTipoPerfil(descricao);
            Id = id;
        }

        private void ValidaTipoPerfil(string descricao)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descricao inválido, Descricao é requerido.");

            DominioExceptionValidation.When(descricao.Length < 3,
                "Descricao inválido, mínimo de 3 caracteres é requerido.");
        }
    }
}
