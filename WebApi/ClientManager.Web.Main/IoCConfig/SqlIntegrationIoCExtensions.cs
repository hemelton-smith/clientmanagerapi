using ClientManager.Integration.Sql.Connections;
using ClientManager.Web.Main.Infrastructure;
using IUA.PolicySales.Integration.Sql.Connections;
using Microsoft.Extensions.DependencyInjection;

namespace ClientManager.Web.Main.IoCConfig
{
    public static class SqlIntegrationIoCExtensions
    {
        public static IServiceCollection AddSqlIntegration(this IServiceCollection services)
        {
            services.AddScoped<IDbSettings, DbSettings>();
            services.AddScoped<IClientManagerDbConnectionContext>(
                provider => new AutoConnectingDbConnectionContext(provider.GetService<IDbSettings>(), settings => settings.ConnectionString)
            );

            return services;
        }
    }
}
