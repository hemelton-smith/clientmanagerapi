using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using Sales.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public interface IGetClientAddressesUseCase
    {
        Task GetClientAddresses(Guid clientId, ISuccessOrErrorActionResultPresenter<List<Address>, ErrorDto> presenter);
    }
}
