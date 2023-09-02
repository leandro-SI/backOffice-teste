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
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public TipoPessoa(string descricao)
        {
            ValidaTipoPessoa(descricao);
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public TipoPessoa(long id, string descricao)
        {
            ValidaTipoPessoa(descricao);
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void Update(string descricao)
        {
            ValidaTipoPessoa(descricao);
            DataAtualizacao = DateTime.Now;
        }

        private void ValidaTipoPessoa(string descricao)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descricao inválido, Descricao é requerido.");

            DominioExceptionValidation.When(descricao.Length < 3,
                "Descricao inválido, mínimo de 3 caracteres é requerido.");

            Descricao = descricao;
        }
    }
}
