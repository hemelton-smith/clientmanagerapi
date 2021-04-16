using ClientManager.Domain.Clients;
using ClientManager.Domain.Clients.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("client")]
    public class ClientController: ControllerBase
    {
        private readonly IAddClientUseCase _addClientUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;

        public ClientController(IAddClientUseCase addClientUseCase, 
            IErrorActionResultPresenter<string> errorPresenter)
        {
            _addClientUseCase = addClientUseCase;
            _presenter = errorPresenter;

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClientRequest clientRequest)
        {
            await _addClientUseCase.AddClient(clientRequest, _presenter);
           return _presenter.Render();
        }

    }

}
