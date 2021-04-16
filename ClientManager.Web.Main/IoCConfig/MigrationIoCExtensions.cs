using System;
using ClientManager.Integration.Sql.Connections;
using ClientManager.Integration.Sql.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace IUA.PolicySales.Web.Main.IoCConfig
{
    public static class MigrationIoCExtensions
    {
        public static IServiceCollection AddMigrations(this IServiceCollection services)
        {
            services.AddTransient(provider =>
            {
                var dbSettings = provider.GetService<IDbSettings>();
                var serviceProvider = (IServiceProvider)new ServiceCollection()
                    .AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb
                        .AddSqlServer()
                        .WithGlobalConnectionString(dbSettings.ConnectionString)
                        .ScanIn(typeof(IMigrationMarker).Assembly)
                        .For
                        .All()
                    )
                    .AddLogging(lb => lb.AddFluentMigratorConsole())
                    .BuildServiceProvider(false);

                return serviceProvider
                    .GetRequiredService<IMigrationRunner>();
            });

            return services;
        }
    }
}