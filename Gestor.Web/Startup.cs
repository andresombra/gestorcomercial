using Gestor.Data;
using Gestor.Dominio.Entidades;
using Gestor.Infra;
using Gestor.Infra.Interface;
using Gestor.Infra.Repository;
using Gestor.Infra.Services;
using Gestor.Infra.Services.Interface;
using Gestor.Web.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Globalization;

namespace Gestor.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(new AutorizacaoActionFilter());
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
            });

            //var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
            //services.AddDbContext<GestorContext>(options =>
            //    options.UseMySql(connection, m=> m.MigrationsAssembly("Gestor.Data")));

            services.AddDbContext<GestorContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MySqlConnectionString")));

            services.AddTransient<GestorContext>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();

            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IPedidoItemRepository, PedidoItemRepository>();

            services.AddTransient<ITipoPessoaRepository, TipoPessoaRepository>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IProdutoService, ProdutoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoItemService, PedidoItemService>();
            
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Definindo a cultura padrão: pt-BR
            //var supportedCultures = new[] { new CultureInfo("pt-BR") };
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Pedidos}/{action=Novo}/{id?}");
                });
            }
            else
            {
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            }

        }
    }
}
