using ClientManager.Domain.Output;
using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class DeleteClientUseCase : IDeleteClientUseCase
    {
        private readonly IClientGateway _clientGateway;

        public DeleteClientUseCase(IClientGateway clientGateway)
        {
            _clientGateway = clientGateway;
        }
        public async Task DeleteClient(Guid id, IErrorActionResultPresenter<string> presenter)
        {
            await _clientGateway.DeleteClient(id);
        }
    }
}
