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
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }

        public Endereco(string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            ValidaEndereco(rua, numero, complemento, cep, cidade, uf);
        }

        public Endereco(long id, string rua, string numero, string complemento, string cep, string cidade, string uf)
        {
            ValidaEndereco(rua, numero, complemento, cep, cidade, uf);
            Id = id;
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
            CEP = cep;
            Cidade = cidade;
            UF = uf;
        }
    }
}
