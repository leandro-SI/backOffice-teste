using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class Departamento : BaseEntity
    {
        public string Nome { get; private set; }
        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public Departamento(string nome)
        {
            ValidaDepartamento(nome);
        }

        public Departamento(string nome, long pessoaId)
        {
            ValidaDepartamento(nome);
            PessoaId = pessoaId;
        }

        private void ValidaDepartamento(string nome)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido, Nome é requerido.");

            DominioExceptionValidation.When(nome.Length < 3,
                "Nome inválido, mínimo de 3 caracteres é requerido.");
        }
    }
}
