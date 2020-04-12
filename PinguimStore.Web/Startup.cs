using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PinguimStore.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using PinguimStore.Dominio.Contratos;
using PinguimStore.Repositorio.Repositorios;
using Microsoft.AspNetCore.Mvc;


namespace PinguimStore.WEB
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetConnectionString("PinguimStoreDB");
            services.AddDbContext<PinguimStoreContexto>(option => option.UseLazyLoadingProxies().UseMySql(connectionString, m => m.MigrationsAssembly("PinguimStore.Repositorio")));

            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    // O Angular iniciado pelo AspNET Core , o processo é mais demorado
                    //spa.UseAngularCliServer(npmScript: "start");

                    // O Angular é iniciado sem a chamada do AspNET Core , já está publicado em outro endereço
                    // C:\PROJETOS\PinguimStore\PinguimStore.WEB\ClientApp\npm start 
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");

                }
            });
        }
    }
}
