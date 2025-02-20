﻿// <auto-generated />
using System;
using Gestor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gestor.Data.Migrations
{
    [DbContext(typeof(GestorContext))]
    [Migration("20200407205054_Pedido e PedidoItem")]
    partial class PedidoePedidoItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gestor.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnName("nm_categoria")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NomeCategoria")
                        .IsUnique();

                    b.ToTable("categoria");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(5212),
                            NomeCategoria = "Sem Categoria",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6402),
                            NomeCategoria = "Livros",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6511),
                            NomeCategoria = "Roupas",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6517),
                            NomeCategoria = "Bebidas",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 4,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6520),
                            NomeCategoria = "Eletronicos",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 5,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6523),
                            NomeCategoria = "Comidas",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 9999,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 29, DateTimeKind.Utc).AddTicks(6526),
                            NomeCategoria = "Outros",
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("PontoReferencia")
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<int>("TipoPedido")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("VendedorId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Qtde")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.ToTable("PedidoItems");
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("Celular")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<int>("LocalizacaoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.Property<int>("Situacao")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int>("TipoPessoaId")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("pessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 41, DateTimeKind.Utc).AddTicks(2020),
                            LocalizacaoId = 0,
                            Nome = "FORNECEDOR",
                            Situacao = 0,
                            TipoPessoaId = 2,
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 41, DateTimeKind.Utc).AddTicks(2094),
                            LocalizacaoId = 0,
                            Nome = "VENDEDOR",
                            Situacao = 0,
                            TipoPessoaId = 3,
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("CodigoSecundario")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("NomeProduto")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<decimal>("QtdeEstoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(65,30)")
                        .HasDefaultValue(0m);

                    b.Property<int>("UnidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCusto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(65,30)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("ValorVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(65,30)")
                        .HasDefaultValue(0m);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoriaId = -1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 59, DateTimeKind.Utc).AddTicks(990),
                            FornecedorId = 1,
                            NomeProduto = "PRODUTO TEMP",
                            QtdeEstoque = 10m,
                            UnidadeId = 1,
                            UsuarioId = 0,
                            ValorCusto = 1m,
                            ValorVenda = 10m
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.TipoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeTipoPessoa")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tipopessoa");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7123),
                            NomeTipoPessoa = "Cliente",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7255),
                            NomeTipoPessoa = "Fornecedor",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7263),
                            NomeTipoPessoa = "Vendedor",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 4,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7265),
                            NomeTipoPessoa = "Transportadora",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 5,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 52, DateTimeKind.Utc).AddTicks(7266),
                            NomeTipoPessoa = "Entregador",
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Unidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeUnidade")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("unidade");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(7505),
                            NomeUnidade = "UNID",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8493),
                            NomeUnidade = "CAIXA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 3,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8522),
                            NomeUnidade = "PCT",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 4,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8526),
                            NomeUnidade = "LT",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 5,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8529),
                            NomeUnidade = "BDJ",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 6,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8532),
                            NomeUnidade = "KG",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 7,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8534),
                            NomeUnidade = "ML",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 8,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8537),
                            NomeUnidade = "GRFA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 9,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8540),
                            NomeUnidade = "FARDO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 10,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8543),
                            NomeUnidade = "DUZIA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 11,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8546),
                            NomeUnidade = "MEIA DUZIA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 12,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8548),
                            NomeUnidade = "AMPOLA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 13,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8551),
                            NomeUnidade = "BALDE",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 14,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8554),
                            NomeUnidade = "BARRA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 15,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8557),
                            NomeUnidade = "BISNAGA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 16,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8560),
                            NomeUnidade = "BLOCO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 17,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8563),
                            NomeUnidade = "BOBINA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 18,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8565),
                            NomeUnidade = "CAPSULA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 19,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8568),
                            NomeUnidade = "CARTELA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 20,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8571),
                            NomeUnidade = "FOLHA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 21,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8573),
                            NomeUnidade = "FRASCO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 22,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8576),
                            NomeUnidade = "CENTO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 23,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8579),
                            NomeUnidade = "GALÃO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 24,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8582),
                            NomeUnidade = "GARRAFA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 25,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8585),
                            NomeUnidade = "GRAMAS",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 26,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8588),
                            NomeUnidade = "JOGO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 27,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8590),
                            NomeUnidade = "KIT",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 28,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8593),
                            NomeUnidade = "LITRO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 29,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8596),
                            NomeUnidade = "PACOTE",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 30,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8598),
                            NomeUnidade = "PALETE",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 31,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8601),
                            NomeUnidade = "PARES",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 32,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8604),
                            NomeUnidade = "PEÇA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 33,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8607),
                            NomeUnidade = "RESMA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 34,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8610),
                            NomeUnidade = "ROLO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 35,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8612),
                            NomeUnidade = "SACO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 36,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8615),
                            NomeUnidade = "SACOLA",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 37,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8618),
                            NomeUnidade = "TAMBOR",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 38,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8621),
                            NomeUnidade = "TUBO",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 39,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8623),
                            NomeUnidade = "VASILHAME",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 40,
                            DataInclusao = new DateTime(2020, 4, 7, 20, 50, 54, 56, DateTimeKind.Utc).AddTicks(8627),
                            NomeUnidade = "VIDRO",
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataInclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            NomeUsuario = "Administrador",
                            Senha = "admin",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 2,
                            Login = "oper",
                            NomeUsuario = "Operador",
                            Senha = "oper",
                            UsuarioId = 0
                        },
                        new
                        {
                            Id = 3,
                            Login = "user",
                            NomeUsuario = "Usuario",
                            Senha = "user",
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Pedido", b =>
                {
                    b.HasOne("Gestor.Dominio.Entidades.Pessoa", "Cliente")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestor.Dominio.Entidades.Pessoa", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.PedidoItem", b =>
                {
                    b.HasOne("Gestor.Dominio.Entidades.Pedido", null)
                        .WithOne("Pedido_Item")
                        .HasForeignKey("Gestor.Dominio.Entidades.PedidoItem", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Pessoa", b =>
                {
                    b.HasOne("Gestor.Dominio.Entidades.TipoPessoa", "TipoPessoa")
                        .WithMany("Pessoas")
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Gestor.Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("Gestor.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestor.Dominio.Entidades.Pessoa", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestor.Dominio.Entidades.Unidade", "Unidade")
                        .WithMany("Produtos")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
