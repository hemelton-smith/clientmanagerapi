using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public interface IUpdateClientAddressesUseCase
    {
        Task UpdateClientAddresses(List<Address> addresses,IErrorActionResultPresenter<string> presenter);
    }
}
