using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestor.Data.Migrations
{
    public partial class Usuarioclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeUsuario = table.Column<string>(maxLength: 50, nullable: false),
                    Login = table.Column<string>(maxLength: 10, nullable: false),
                    Senha = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "Login", "NomeUsuario", "Senha", "UsuarioId" },
                values: new object[] { 1, null, null, "admin", "Administrador", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "Login", "NomeUsuario", "Senha", "UsuarioId" },
                values: new object[] { 2, null, null, "oper", "Operador", "oper", 0 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "Login", "NomeUsuario", "Senha", "UsuarioId" },
                values: new object[] { 3, null, null, "user", "Usuario", "user", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
