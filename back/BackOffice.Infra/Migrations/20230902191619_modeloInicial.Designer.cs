﻿// <auto-generated />
using System;
using BackOffice.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackOffice.Infra.Migrations
{
    [DbContext(typeof(BackOfficeContext))]
    [Migration("20230902191619_modeloInicial")]
    partial class modeloInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackOffice.Dominio.Entities.Departamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("PessoaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.HasIndex("PessoaId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("QualificacaoId")
                        .HasColumnType("bigint");

                    b.Property<long>("TipoPessoaId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.HasIndex("EnderecoId");

                    b.HasIndex("QualificacaoId");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Qualificacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("Qualificacoes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4148),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4115),
                            Descricao = "Cliente"
                        },
                        new
                        {
                            Id = 2L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4150),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4150),
                            Descricao = "Fornecedor"
                        },
                        new
                        {
                            Id = 3L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4152),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4151),
                            Descricao = "Colaborador"
                        });
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.TipoPerfil", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("TipoPerfis");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5157),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5155),
                            Descricao = "Administrador"
                        },
                        new
                        {
                            Id = 2L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5160),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5159),
                            Descricao = "Usuario"
                        });
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.TipoPessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("TipoPessoas");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5942),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5939),
                            Descricao = "Fisica"
                        },
                        new
                        {
                            Id = 2L,
                            DataAtualizacao = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5944),
                            DataCadastro = new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5943),
                            Descricao = "Juridica"
                        });
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("TipoPerfilId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("TipoPerfilId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Departamento", b =>
                {
                    b.HasOne("BackOffice.Dominio.Entities.Pessoa", "Pessoa")
                        .WithMany("Departamentos")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Pessoa", b =>
                {
                    b.HasOne("BackOffice.Dominio.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackOffice.Dominio.Entities.Qualificacao", "Qualificacao")
                        .WithMany()
                        .HasForeignKey("QualificacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackOffice.Dominio.Entities.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Qualificacao");

                    b.Navigation("TipoPessoa");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Usuario", b =>
                {
                    b.HasOne("BackOffice.Dominio.Entities.TipoPerfil", "TipoPerfil")
                        .WithMany()
                        .HasForeignKey("TipoPerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPerfil");
                });

            modelBuilder.Entity("BackOffice.Dominio.Entities.Pessoa", b =>
                {
                    b.Navigation("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
