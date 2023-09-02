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
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Usuario(string login, string email)
        {
            ValidaUsuario(login, email);
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Usuario(long id, string login, string email)
        {
            ValidaUsuario(login, email);
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Usuario(string login, string email, long tipoPerfilId)
        {
            ValidaUsuario(login, email);
            TipoPerfilId = tipoPerfilId;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void Update(string login, string email)
        {
            ValidaUsuario(login, email);
            DataAtualizacao = DateTime.Now;
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
