using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Domain.Clients;
using ClientManager.Domain.Clients.UseCase;
using ClientManager.Integration.Sql.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace ClientManager.Web.Main.IoCConfig
{
    public static class ClientIoCExtensions
    {
        public static IServiceCollection AddClient(this IServiceCollection services)
        {
            services.AddScoped<IClientGateway, ClientGateway>();
            services.AddScoped<IAddClientUseCase, AddClientUseCase>();
            services.AddScoped<IUpdateClientUseCase, UpdateClientUseCase>();
            services.AddScoped<IGetAllClientsUseCase, GetAllClientsUseCase>();
            services.AddScoped<IGetClientByIdUseCase, GetClientByIdUseCase>();
            services.AddScoped<IDeleteClientUseCase, DeleteClientUseCase>();
            services.AddScoped<IExportClientInformationUseCase, ExportClientInformationUseCase>();
            return services;
        }
    }
}
