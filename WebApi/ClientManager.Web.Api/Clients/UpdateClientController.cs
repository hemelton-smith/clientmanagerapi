using ClientManager.Domain.Clients;
using ClientManager.Domain.Clients.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("updateclient")]
    public class UpdateClientController : ControllerBase
    {
        private readonly IUpdateClientUseCase _updateClientUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;

        public UpdateClientController(IUpdateClientUseCase updateClientUseCase,
            IErrorActionResultPresenter<string> errorPresenter)
        {
            _updateClientUseCase = updateClientUseCase;
            _presenter = errorPresenter;
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddClientRequest client)
        {
           await _updateClientUseCase.UpdateClient(client, _presenter);
            return _presenter.Render();
        }
    }
}
