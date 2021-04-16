using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Domain.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Addresses
{
    [ApiController]
    [Route("deleterecord")]
    public class DeleteAddressController : ControllerBase
    {
        private readonly IDeleteAddressUseCase _deleteAddressUseCase;
        private readonly IErrorActionResultPresenter<string> _presenter;

        public DeleteAddressController(IDeleteAddressUseCase deleteAddressUseCase,
            IErrorActionResultPresenter<string> presenter)
        {
            _deleteAddressUseCase = deleteAddressUseCase;
            _presenter = presenter;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(Guid clientId)
        {
            await _deleteAddressUseCase.DeleteAddress(clientId, _presenter);
            return _presenter.Render();
        }
    }
}
