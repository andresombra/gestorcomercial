using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gestor.Data.Migrations
{
    public partial class PedidoePedidoItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    nm_categoria = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipopessoa",
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
                    table.PrimaryKey("PK_tipopessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unidade",
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
                    table.PrimaryKey("PK_unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
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
                    table.PrimaryKey("PK_usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
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
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pessoa_tipopessoa_TipoPessoaId",
                        column: x => x.TipoPessoaId,
                        principalTable: "tipopessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    TipoPedido = table.Column<int>(nullable: false),
                    Situacao = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    VendedorId = table.Column<int>(nullable: false),
                    Endereco = table.Column<string>(maxLength: 500, nullable: true),
                    PontoReferencia = table.Column<string>(maxLength: 500, nullable: true),
                    Telefone = table.Column<string>(maxLength: 20, nullable: true),
                    Celular = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pedido_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_pessoa_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NomeProduto = table.Column<string>(maxLength: 200, nullable: true),
                    UnidadeId = table.Column<int>(nullable: false, defaultValue: 0),
                    CategoriaId = table.Column<int>(nullable: false, defaultValue: 0),
                    FornecedorId = table.Column<int>(nullable: false, defaultValue: 0),
                    CodigoSecundario = table.Column<string>(maxLength: 50, nullable: true),
                    ValorVenda = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    ValorCusto = table.Column<decimal>(nullable: false, defaultValue: 0m),
                    QtdeEstoque = table.Column<decimal>(nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_pessoa_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "unidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PedidoId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    DataInclusao = table.Column<DateTime>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    Qtde = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categoria",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "nm_categoria", "UsuarioId" },
                values: new object[,]
                {
                    { -1, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(5212), "Sem Categoria", 0 },
                    { 1, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6402), "Livros", 0 },
                    { 2, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6511), "Roupas", 0 },
                    { 3, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6517), "Bebidas", 0 },
                    { 4, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6520), "Eletronicos", 0 },
                    { 5, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6523), "Comidas", 0 },
                    { 9999, null, new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6526), "Outros", 0 }
                });

            migrationBuilder.InsertData(
                table: "tipopessoa",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "NomeTipoPessoa", "UsuarioId" },
                values: new object[,]
                {
                    { 5, null, new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7266), "Entregador", 0 },
                    { 3, null, new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7263), "Vendedor", 0 },
                    { 4, null, new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7265), "Transportadora", 0 },
                    { 1, null, new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7123), "Cliente", 0 },
                    { 2, null, new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7255), "Fornecedor", 0 }
                });

            migrationBuilder.InsertData(
                table: "unidade",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "NomeUnidade", "UsuarioId" },
                values: new object[,]
                {
                    { 30, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8598), "PALETE", 0 },
                    { 23, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8579), "GALÃO", 0 },
                    { 24, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8582), "GARRAFA", 0 },
                    { 25, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8585), "GRAMAS", 0 },
                    { 26, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8588), "JOGO", 0 },
                    { 27, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8590), "KIT", 0 },
                    { 28, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8593), "LITRO", 0 },
                    { 29, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8596), "PACOTE", 0 },
                    { 31, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8601), "PARES", 0 },
                    { 37, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8618), "TAMBOR", 0 },
                    { 33, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8607), "RESMA", 0 },
                    { 34, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8610), "ROLO", 0 },
                    { 35, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8612), "SACO", 0 },
                    { 36, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8615), "SACOLA", 0 },
                    { 22, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8576), "CENTO", 0 },
                    { 38, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8621), "TUBO", 0 },
                    { 39, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8623), "VASILHAME", 0 },
                    { 40, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8627), "VIDRO", 0 },
                    { 32, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8604), "PEÇA", 0 },
                    { 21, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8573), "FRASCO", 0 },
                    { 16, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8560), "BLOCO", 0 },
                    { 19, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8568), "CARTELA", 0 },
                    { 1, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(7505), "UNID", 0 },
                    { 2, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8493), "CAIXA", 0 },
                    { 3, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8522), "PCT", 0 },
                    { 4, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8526), "LT", 0 },
                    { 5, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8529), "BDJ", 0 },
                    { 6, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8532), "KG", 0 },
                    { 7, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8534), "ML", 0 },
                    { 8, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8537), "GRFA", 0 },
                    { 20, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8571), "FOLHA", 0 },
                    { 9, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8540), "FARDO", 0 },
                    { 11, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8546), "MEIA DUZIA", 0 },
                    { 12, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8548), "AMPOLA", 0 },
                    { 13, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8551), "BALDE", 0 },
                    { 14, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8554), "BARRA", 0 },
                    { 15, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8557), "BISNAGA", 0 },
                    { 17, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8563), "BOBINA", 0 },
                    { 18, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8565), "CAPSULA", 0 },
                    { 10, null, new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8543), "DUZIA", 0 }
                });

            migrationBuilder.InsertData(
                table: "usuario",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "Login", "NomeUsuario", "Senha", "UsuarioId" },
                values: new object[,]
                {
                    { 2, null, null, "oper", "Operador", "oper", 0 },
                    { 1, null, null, "admin", "Administrador", "admin", 0 },
                    { 3, null, null, "user", "Usuario", "user", 0 }
                });

            migrationBuilder.InsertData(
                table: "pessoa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Complemento", "CpfCnpj", "DataAtualizacao", "DataInclusao", "Email", "Endereco", "Estado", "LocalizacaoId", "Nome", "Situacao", "Telefone", "TipoPessoaId", "UF", "UsuarioId" },
                values: new object[] { 1, null, null, null, null, null, null, null, new DateTime(2020, 4, 7, 20, 50, 54, 41, DateTimeKind.Utc).AddTicks(2020), null, null, null, 0, "FORNECEDOR", 0, null, 2, null, 0 });

            migrationBuilder.InsertData(
                table: "pessoa",
                columns: new[] { "Id", "Bairro", "Celular", "Cep", "Cidade", "Complemento", "CpfCnpj", "DataAtualizacao", "DataInclusao", "Email", "Endereco", "Estado", "LocalizacaoId", "Nome", "Situacao", "Telefone", "TipoPessoaId", "UF", "UsuarioId" },
                values: new object[] { 2, null, null, null, null, null, null, null, new DateTime(2020, 4, 7, 20, 50, 54, 41, DateTimeKind.Utc).AddTicks(2094), null, null, null, 0, "VENDEDOR", 0, null, 3, null, 0 });

            migrationBuilder.InsertData(
                table: "produto",
                columns: new[] { "Id", "CategoriaId", "CodigoSecundario", "DataAtualizacao", "DataInclusao", "FornecedorId", "NomeProduto", "QtdeEstoque", "UnidadeId", "UsuarioId", "ValorCusto", "ValorVenda" },
                values: new object[] { 1, -1, null, null, new DateTime(2020, 4, 7, 20, 50, 54, 59, DateTimeKind.Utc).AddTicks(990), 1, "PRODUTO TEMP", 10m, 1, 0, 1m, 10m });

            migrationBuilder.CreateIndex(
                name: "IX_categoria_nm_categoria",
                table: "categoria",
                column: "nm_categoria",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_PessoaId",
                table: "pedido",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_VendedorId",
                table: "pedido",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoItems_PedidoId",
                table: "PedidoItems",
                column: "PedidoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_TipoPessoaId",
                table: "pessoa",
                column: "TipoPessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_CategoriaId",
                table: "produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_FornecedorId",
                table: "produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_UnidadeId",
                table: "produto",
                column: "UnidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoItems");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "unidade");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "tipopessoa");
        }
    }
}
