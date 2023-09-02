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
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Nome).HasMaxLength(50).IsRequired();
            builder.HasIndex(d => d.Nome).IsUnique();

            builder.HasOne(d => d.Pessoa).WithMany(p => p.Departamentos)
                .HasForeignKey(p => p.PessoaId);
               

        }
    }
}
