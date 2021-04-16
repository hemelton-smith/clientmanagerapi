using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Addresses
{
    [ApiController]
    [Route("clientaddresses")]
    public class ClientAddressesController : ControllerBase
    {
        private readonly IGetClientAddressesUseCase _getClientAddressesUseCase;
        private readonly ISuccessOrErrorActionResultPresenter<List<Address>, ErrorDto> _presenter;

        public ClientAddressesController(IGetClientAddressesUseCase getClientAddressesUseCase, ISuccessOrErrorActionResultPresenter<List<Address>, ErrorDto> presenter)
        {
            _getClientAddressesUseCase = getClientAddressesUseCase;
            _presenter = presenter;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientAddresses(Guid clientId)
        {
            await _getClientAddressesUseCase.GetClientAddresses(clientId, _presenter);
            return _presenter.Render();
        }
    }
}
