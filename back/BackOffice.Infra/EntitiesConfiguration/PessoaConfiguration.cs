using BackOffice.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Infra.EntitiesConfiguration
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Documento).HasMaxLength(14).IsRequired();
            builder.HasIndex(p => p.Documento).IsUnique();
            builder.Property(p => p.Apelido).HasMaxLength(100).IsRequired();
            builder.Property(p => p.TipoPessoaId).IsRequired();
            builder.Property(p => p.EnderecoId).IsRequired();
            builder.Property(p => p.QualificacaoId).IsRequired();

            builder.HasOne(p => p.TipoPessoa)
               .WithMany()
               .HasForeignKey(p => p.TipoPessoaId);

            builder.HasOne(p => p.Endereco)
               .WithMany()
               .HasForeignKey(p => p.EnderecoId);

            builder.HasOne(p => p.Qualificacao)
               .WithMany()
               .HasForeignKey(p => p.QualificacaoId);

        }
    }
}
