using ClientManager.Domain.Addresses;
using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Integration.Sql.Address;
using Microsoft.Extensions.DependencyInjection;

namespace ClientManager.Web.Main.IoCConfig
{
    public static class AddressIoCExtensions
    {
        public static IServiceCollection AddAddress(this IServiceCollection services)
        {
            services.AddScoped<IAddressGateway, AddressGateway>();
            services.AddScoped<IInsertAddressUseCase, InsertAddressUseCase>();
            services.AddScoped<IDeleteAddressUseCase, DeleteAddressUseCase>();
            services.AddScoped<IGetClientAddressesUseCase, GetClientAddressesUseCase>();
            services.AddScoped<IUpdateClientAddressesUseCase, UpdateClientAddressesUseCase>();
            return services;
        }
    }
}
