using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public class UpdateClientAddressesUseCase : IUpdateClientAddressesUseCase
    {
        private readonly IAddressGateway _addressGateway;

        public UpdateClientAddressesUseCase(IAddressGateway addressGateway)
        {
            _addressGateway = addressGateway;
        }
        public async Task UpdateClientAddresses(List<Address> address, IErrorActionResultPresenter<string> presenter)
        {
            await _addressGateway.UpdateClientAddresses(address);
        }

    }
}
