using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public class DeleteAddressUseCase : IDeleteAddressUseCase
    {
        private readonly IAddressGateway _addressGateway;
        private readonly IClientGateway _clientGateway;
        
        public DeleteAddressUseCase(IAddressGateway addressGateway, IClientGateway clientGateway)
        {
            _addressGateway = addressGateway;
            _clientGateway = clientGateway;
        }
        public async Task DeleteAddress(Guid clientId, IErrorActionResultPresenter<string> presenter)
        {
           await _addressGateway.DeleteAddress(clientId);
           await _clientGateway.DeleteClient(clientId);
        }

    
    }
}
