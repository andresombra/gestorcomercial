using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Gestor.Data.Config;
using Gestor.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Gestor.Data
{
    public partial class GestorContext : DbContext
    {
        public static IConfiguration _configuration { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<TipoPessoa> TipoPessoas { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Unidade> Unidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }

        public GestorContext()
        {
        }
        
        public GestorContext(DbContextOptions<GestorContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySQL("server=localhost; database=gestordb; user=andre; password=196820");
            
            //var stringConexao = _configuration.GetSection("ConexaoMySql").GetSection("MySqlConnectionString").Value;
            
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=localhost;user id=andre;password=196820;database=gestordb"
                //    , x => x.ServerVersion("8.0.19-mysql").MigrationsAssembly("Gestor.Data"));

                //optionsBuilder.UseMySql(stringConexao
                //    , mysqlOptions => { mysqlOptions.ServerVersion(new Version(8, 0, 19), ServerType.MySql); });

                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");
                _configuration = builder.Build();

                optionsBuilder.UseMySql(_configuration.GetConnectionString("MySqlConnectionString")
                    , mysqlOptions => { mysqlOptions.ServerVersion(new Version(8, 0, 19), ServerType.MySql); });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            //modelBuilder.ApplyConfiguration(new TipoPessoaConfiguration());
            //modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
            //modelBuilder.ApplyConfiguration(new UnidadeConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //modelBuilder.ApplyConfiguration(new PedidoConfiguration());

            //No lugar do metodo acima ApplyConfiguration, localiza as class que implementa IEntityTypeConfiguration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GestorContext).Assembly);

            modelBuilder.Entity<Produto>().HasData(
               new Produto() { Id = 1, CategoriaId = -1, FornecedorId = 1, UnidadeId = 1,
                   NomeProduto = "PRODUTO TEMP", ValorVenda = 10m, ValorCusto = 1m, 
                   QtdeEstoque = 10m, DataInclusao = DateTime.UtcNow });

            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
