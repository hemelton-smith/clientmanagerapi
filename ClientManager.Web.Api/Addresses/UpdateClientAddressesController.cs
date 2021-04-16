using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Addresses
{
    [ApiController]
    [Route("updateaddresses")]
    public class UpdateClientAddressesController : ControllerBase
    {
        private readonly IUpdateClientAddressesUseCase _updateClientAddressesUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;

        public UpdateClientAddressesController(IUpdateClientAddressesUseCase updateClientAddressesUseCase
            ,IErrorActionResultPresenter<string> presenter)
        {
            _updateClientAddressesUseCase = updateClientAddressesUseCase;
            _presenter = presenter;
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClientAddresses(List<Domain.Clients.Address> address)
        {
            await _updateClientAddressesUseCase.UpdateClientAddresses(address, _presenter);
            return _presenter.Render();

        }
    }
}
