using ClientManager.Domain.Clients.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("deleteclient")]
    public class DeleteClientController : ControllerBase
    {
        private readonly IDeleteClientUseCase _deleteClientUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;

        public DeleteClientController(IDeleteClientUseCase deleteClientUseCase, 
            IErrorActionResultPresenter<string> errorPresenter)
        {
            _deleteClientUseCase = deleteClientUseCase;
            _presenter = errorPresenter;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            await _deleteClientUseCase.DeleteClient(id, _presenter);
            return _presenter.Render();
        }
    }
}
