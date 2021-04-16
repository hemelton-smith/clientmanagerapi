using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class GetClientByIdUseCase : IGetClientByIdUseCase
    {
        private readonly IClientGateway _clientGateway;

        public GetClientByIdUseCase(IClientGateway clientGateway)
        {
            _clientGateway = clientGateway;
        }
        public async Task<Client> GetClientById(Guid id)
        {
           return await _clientGateway.GetAllClientById(id);
        }
    }
}
