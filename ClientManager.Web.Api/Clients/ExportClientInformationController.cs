using ClientManager.Domain.Clients.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("export")]
    public class ExportClientInformationController : ControllerBase
    {
        private readonly IExportClientInformationUseCase _exportClientInformationUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;


        public ExportClientInformationController(IExportClientInformationUseCase exportClientInformationUseCase,
            IErrorActionResultPresenter<string> errorPresenter)
        {
            _exportClientInformationUseCase = exportClientInformationUseCase;
            _presenter = errorPresenter;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientsInformation()
        {
             await _exportClientInformationUseCase.GetClientsInformation(_presenter);

            return _presenter.Render();
        }
    }
}
