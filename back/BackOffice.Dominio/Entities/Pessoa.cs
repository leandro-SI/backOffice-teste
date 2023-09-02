using BackOffice.Dominio.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Entities
{
    public sealed class Pessoa : BaseEntity
    {
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Apelido { get; private set; }
        public long TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public long EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public long QualificacaoId { get; set; }
        public Qualificacao Qualificacao { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public Pessoa(string nome, string documento, string apelido)
        {
            ValidaPessoa(nome, documento, apelido);
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public Pessoa(long id, string nome, string documento, string apelido)
        {
            ValidaPessoa(nome, documento, apelido);
            DominioExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            DataCadastro = DateTime.Now;
            DataAtualizacao = DateTime.Now;
        }

        public void Update(string nome, string documento, string apelido, long tipoPessoaId, long enderecoId, long qualificacaoId)
        {
            ValidaPessoa(nome, documento, apelido);
            TipoPessoaId = tipoPessoaId;
            EnderecoId = enderecoId;
            QualificacaoId = qualificacaoId;
            DataAtualizacao = DateTime.Now;
        }

        private void ValidaPessoa(string nome, string documento, string apelido)
        {
            DominioExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome inválido, Nome é requerido.");

            DominioExceptionValidation.When(nome.Length < 3,
                "Nome inválido, mínimo de 3 caracteres é requerido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(documento),
                "Documento inválido, Documento é requerido.");

            DominioExceptionValidation.When(documento.Length != 11 && documento.Length != 14,
                "Documento inválido, Documento não é um identificador válido.");

            DominioExceptionValidation.When(string.IsNullOrEmpty(apelido),
                "Apelido inválido, Nome é requerido.");

            DominioExceptionValidation.When(apelido.Length < 3,
                "Apelido inválido, mínimo de 3 caracteres é requerido.");

            Nome = nome;
            Documento = documento;
            Apelido = apelido;
        }

    }
}
