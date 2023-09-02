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
    public class QualificacaoConfiguration : IEntityTypeConfiguration<Qualificacao>
    {
        public void Configure(EntityTypeBuilder<Qualificacao> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).HasMaxLength(50).IsRequired();
            builder.HasIndex(t => t.Descricao).IsUnique();

            builder.HasData(
                new Qualificacao(1, "Cliente"),
                new Qualificacao(2, "Fornecedor"),
                new Qualificacao(3, "Colaborador")
            );
        }
    }
}
