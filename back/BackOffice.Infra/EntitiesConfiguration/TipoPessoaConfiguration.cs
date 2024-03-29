﻿using BackOffice.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Infra.EntitiesConfiguration
{
    public class TipoPessoaConfiguration : IEntityTypeConfiguration<TipoPessoa>
    {
        public void Configure(EntityTypeBuilder<TipoPessoa> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Descricao).HasMaxLength(50).IsRequired();
            builder.HasIndex(t => t.Descricao).IsUnique();

            builder.HasData(
                new TipoPessoa(1, "Fisica"),
                new TipoPessoa(2, "Juridica")
            );
        }
    }
}
