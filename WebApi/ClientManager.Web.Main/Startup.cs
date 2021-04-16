using ClientManager.Integration.Sql.Infrastructure;
using ClientManager.Web.Main.Infrastructure;
using ClientManager.Web.Main.IoCConfig;
using ClientManager.Web.Main.IoCConfigs;
using FluentMigrator.Runner;
using IUA.PolicySales.Web.Main.IoCConfig;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientManager.Web.Main
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
            services.AddMigrations()
                .AddSqlIntegration()
                .AddClient()
                .AddAddress()
                .AddPresenters()
                .AddControllers();
       
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            RunDbMigrations(app);
        }

        private void RunDbMigrations(IApplicationBuilder app)
        {
            using var startupScope = app.ApplicationServices.CreateScope();
            var migrationRunner = startupScope.ServiceProvider.GetService<IMigrationRunner>();
            migrationRunner.MigrateUp();
        }
    }
}
