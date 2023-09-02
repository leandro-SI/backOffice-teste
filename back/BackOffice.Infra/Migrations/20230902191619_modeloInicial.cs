using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackOffice.Infra.Migrations
{
    public partial class modeloInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualificacoes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualificacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPerfis",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPerfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoPerfilId = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_TipoPerfis_TipoPerfilId",
                        column: x => x.TipoPerfilId,
                        principalTable: "TipoPerfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoPessoaId = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false),
                    QualificacaoId = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_Qualificacoes_QualificacaoId",
                        column: x => x.QualificacaoId,
                        principalTable: "Qualificacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pessoas_TipoPessoas_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PessoaId = table.Column<long>(type: "bigint", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Qualificacoes",
                columns: new[] { "Id", "DataAtualizacao", "DataCadastro", "Descricao" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4148), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4115), "Cliente" },
                    { 2L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4150), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4150), "Fornecedor" },
                    { 3L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4152), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(4151), "Colaborador" }
                });

            migrationBuilder.InsertData(
                table: "TipoPerfis",
                columns: new[] { "Id", "DataAtualizacao", "DataCadastro", "Descricao" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5157), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5155), "Administrador" },
                    { 2L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5160), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5159), "Usuario" }
                });

            migrationBuilder.InsertData(
                table: "TipoPessoas",
                columns: new[] { "Id", "DataAtualizacao", "DataCadastro", "Descricao" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5942), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5939), "Fisica" },
                    { 2L, new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5944), new DateTime(2023, 9, 2, 16, 16, 16, 652, DateTimeKind.Local).AddTicks(5943), "Juridica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_Nome",
                table: "Departamentos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PessoaId",
                table: "Departamentos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_Documento",
                table: "Pessoas",
                column: "Documento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_QualificacaoId",
                table: "Pessoas",
                column: "QualificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TipoPessoaId",
                table: "Pessoas",
                column: "TipoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualificacoes_Descricao",
                table: "Qualificacoes",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPerfis_Descricao",
                table: "TipoPerfis",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoPessoas_Descricao",
                table: "TipoPessoas",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoPerfilId",
                table: "Usuarios",
                column: "TipoPerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "TipoPerfis");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Qualificacoes");

            migrationBuilder.DropTable(
                name: "TipoPessoas");
        }
    }
}
