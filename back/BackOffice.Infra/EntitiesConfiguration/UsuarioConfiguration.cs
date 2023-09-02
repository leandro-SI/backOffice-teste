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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Login).HasMaxLength(100).IsRequired();
            builder.HasIndex(u => u.Login).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(150).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.TipoPerfilId).IsRequired();

            builder.HasOne(u => u.TipoPerfil)
                   .WithMany()
                   .HasForeignKey(u => u.TipoPerfilId);
        }
    }
}
