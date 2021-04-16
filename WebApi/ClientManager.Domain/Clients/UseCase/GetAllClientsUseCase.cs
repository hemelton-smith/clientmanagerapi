using ClientManager.Domain.Output;
using Sales.Domain.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class GetAllClientsUseCase : IGetAllClientsUseCase
    {
        private readonly IClientGateway _clientGateway;

        public GetAllClientsUseCase(IClientGateway clientGateway)
        {
            _clientGateway = clientGateway;
        }
        public async Task Execute(ISuccessOrErrorActionResultPresenter<List<Client>, ErrorDto> presenter)
        {
           var clients = await _clientGateway.GetAllClients();

            if(clients.Count > 0)
            {
                presenter.Success(clients);
            }
            else
            {
                presenter.Error(new ErrorDto
                {
                    Message = "No clients found"
                });
            }
            
        }
    }
}
