using BackOffice.Dominio.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class Usuario : BaseEntity
    {
        public string Login { get; private set; }
        public string Email { get; private set; }
        public long TipoPerfilId { get; set; }
        public TipoPerfil TipoPerfil { get; set; }

        public Usuario(string login, string email)
        {
            ValidaUsuario(login, email);
        }

        public Usuario(string login, string email, long tipoPerfilId)
        {
            ValidaUsuario(login, email);
            TipoPerfilId = tipoPerfilId;
        }

        private void ValidaUsuario(string login, string email)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(login),
                "Login inválido, Login é requerido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(email),
                "Email inválido, Email é requerido.");
        }
    }
}
