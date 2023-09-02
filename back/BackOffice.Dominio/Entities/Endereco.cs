using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class Endereco : BaseEntity
    {
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Endereco(string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            ValidaEndereco(rua, numero, complemento, cep, cidade, uf);
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Endereco(long id, string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            ValidaEndereco(rua, numero, complemento, cep, cidade, uf);
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void Update(string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            ValidaEndereco(rua, numero, complemento, cep,cidade, uf);
            DataAtualizacao = DateTime.Now;
        }


        private void ValidaEndereco(string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(rua),
                "Rua inválido, Rua é requerido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(cep),
                "CEP inválido, CEP é requerido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(cidade),
                "Cidade inválido, Cidade é requerido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(uf),
                "UF inválido, UF é requerido.");

            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
        }
    }
}
