using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestor.Data.Migrations
{
    public partial class Primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeCategoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeTipoPessoa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeUnidade = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Endereco = table.Column<string>(maxLength: 150, nullable: true),
                    Bairro = table.Column<string>(maxLength: 150, nullable: true),
                    Cep = table.Column<string>(maxLength: 10, nullable: true),
                    LocalizacaoId = table.Column<int>(nullable: false),
                    Cidade = table.Column<string>(maxLength: 100, nullable: true),
                    Estado = table.Column<string>(maxLength: 100, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    Complemento = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Telefone = table.Column<string>(maxLength: 15, nullable: true),
                    Celular = table.Column<string>(maxLength: 15, nullable: true),
                    CpfCnpj = table.Column<string>(maxLength: 20, nullable: true),
                    Situacao = table.Column<int>(nullable: false),
                    TipoPessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_TipoPessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "TipoPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeProduto = table.Column<string>(maxLength: 200, nullable: true),
                    UnidadeId = table.Column<int>(nullable: false),
                    CodigoSecundario = table.Column<string>(maxLength: 50, nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    ValorVenda = table.Column<decimal>(nullable: false),
                    ValorCusto = table.Column<decimal>(nullable: false),
                    QtdeEstoque = table.Column<decimal>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Pessoa_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produto_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "NomeCategoria", "UsuarioId" },
                values: new object[,]
                {
                    { 1, null, null, "Livros", 0 },
                    { 2, null, null, "Roupas", 0 },
                    { 3, null, null, "Bebidas", 0 },
                    { 4, null, null, "Eletronicos", 0 },
                    { 5, null, null, "Comidas", 0 }
                });

            migrationBuilder.InsertData(
                table: "TipoPessoa",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "NomeTipoPessoa", "UsuarioId" },
                values: new object[,]
                {
                    { 5, null, null, "Entregador", 0 },
                    { 3, null, null, "Vendedor", 0 },
                    { 4, null, null, "Transportadora", 0 },
                    { 1, null, null, "Cliente", 0 },
                    { 2, null, null, "Fornecedor", 0 }
                });

            migrationBuilder.InsertData(
                table: "Unidade",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "NomeUnidade", "UsuarioId" },
                values: new object[,]
                {
                    { 28, null, null, "LITRO", 0 },
                    { 22, null, null, "CENTO", 0 },
                    { 23, null, null, "GALÃO", 0 },
                    { 24, null, null, "GARRAFA", 0 },
                    { 25, null, null, "GRAMAS", 0 },
                    { 26, null, null, "JOGO", 0 },
                    { 27, null, null, "KIT", 0 },
                    { 29, null, null, "PACOTE", 0 },
                    { 34, null, null, "ROLO", 0 },
                    { 31, null, null, "PARES", 0 },
                    { 32, null, null, "PEÇA", 0 },
                    { 33, null, null, "RESMA", 0 },
                    { 21, null, null, "FRASCO", 0 },
                    { 35, null, null, "SACO", 0 },
                    { 36, null, null, "SACOLA", 0 },
                    { 37, null, null, "TAMBOR", 0 },
                    { 38, null, null, "TUBO", 0 },
                    { 30, null, null, "PALETE", 0 },
                    { 20, null, null, "FOLHA", 0 },
                    { 15, null, null, "BISNAGA", 0 },
                    { 18, null, null, "CAPSULA", 0 },
                    { 1, null, null, "UNID", 0 },
                    { 2, null, null, "CAIXA", 0 },
                    { 3, null, null, "PCT", 0 },
                    { 4, null, null, "LT", 0 },
                    { 5, null, null, "BDJ", 0 },
                    { 6, null, null, "KG", 0 },
                    { 7, null, null, "ML", 0 },
                    { 8, null, null, "GRFA", 0 },
                    { 9, null, null, "FARDO", 0 },
                    { 10, null, null, "DUZIA", 0 },
                    { 11, null, null, "MEIA DUZIA", 0 },
                    { 12, null, null, "AMPOLA", 0 },
                    { 13, null, null, "BALDE", 0 },
                    { 14, null, null, "BARRA", 0 },
                    { 39, null, null, "VASILHAME", 0 },
                    { 16, null, null, "BLOCO", 0 },
                    { 17, null, null, "BOBINA", 0 },
                    { 19, null, null, "CARTELA", 0 },
                    { 40, null, null, "VIDRO", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TipoPessoaId",
                table: "Pessoa",
                column: "TipoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_UnidadeId",
                table: "Produto",
                column: "UnidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "TipoPessoa");
        }
    }
}
