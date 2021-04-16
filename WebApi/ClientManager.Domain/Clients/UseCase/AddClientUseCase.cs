using ClientManager.Domain.Addresses;
using ClientManager.Domain.Output;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class AddClientUseCase : IAddClientUseCase
    {
        private readonly IClientGateway _clientGateway;
        private readonly IAddressGateway _addressGateway;

        public AddClientUseCase(IClientGateway clientGateway, IAddressGateway addressGateway)
        {
            _clientGateway = clientGateway;
            _addressGateway = addressGateway;
        }

        public async Task AddClient(AddClientRequest clientResponse, IErrorActionResultPresenter<string> presenter)
        {
            await _clientGateway.CreateClient(clientResponse.Client);
            await _addressGateway.InsertAddress(clientResponse.Addresses);
        }
    }
}
