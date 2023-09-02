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
    public class TipoPerfilConfiguration : IEntityTypeConfiguration<TipoPerfil>
    {
        public void Configure(EntityTypeBuilder<TipoPerfil> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).HasMaxLength(50).IsRequired();
            builder.HasIndex(t => t.Descricao).IsUnique();

            builder.HasData(
                new TipoPerfil(1, "Administrador"),
                new TipoPerfil(2, "Usuario")
            );
        }
    }
}
