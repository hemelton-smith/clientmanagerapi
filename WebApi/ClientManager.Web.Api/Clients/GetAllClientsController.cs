using ClientManager.Domain.Clients;
using ClientManager.Domain.Clients.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("getallclients")]
    public class GetAllClientsController : ControllerBase
    {
        private readonly IGetAllClientsUseCase _getAllClientsUseCase;
        private readonly ISuccessOrErrorActionResultPresenter<List<Client>, ErrorDto> _presenter;
        public GetAllClientsController(IGetAllClientsUseCase getAllClientsUseCase, ISuccessOrErrorActionResultPresenter<List<Client>, ErrorDto> presenter)
        {
            _getAllClientsUseCase = getAllClientsUseCase;
            _presenter = presenter;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
             await _getAllClientsUseCase.Execute(_presenter);
            return _presenter.Render();
        }
    }
}
