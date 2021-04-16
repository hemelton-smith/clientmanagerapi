
using ClientManager.Domain.Addresses;
using ClientManager.Domain.Output;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class UpdateClientUseCase : IUpdateClientUseCase
    {
        private readonly IClientGateway _clientGateway;
        private readonly IAddressGateway _addressGateway;

        public UpdateClientUseCase(IClientGateway clientGateway, IAddressGateway addressGateway)
        {
            _clientGateway = clientGateway;
            _addressGateway = addressGateway;
        }
        public async Task UpdateClient(AddClientRequest client, IErrorActionResultPresenter<string> presenter)
        {
            await _clientGateway.UpdateClient(client.Client);
            await _addressGateway.UpdateClientAddresses(client.Addresses);
        }
    }
}
