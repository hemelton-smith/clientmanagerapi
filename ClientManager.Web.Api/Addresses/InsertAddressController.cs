using ClientManager.Domain.Addresses.UseCase;
using ClientManager.Domain.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("insertAddress")]
    public class InsertAddressController : ControllerBase
    {
        private readonly IInsertAddressUseCase _insertAddressUseCase;

        public InsertAddressController(IInsertAddressUseCase insertAddressUseCase)
        {
            _insertAddressUseCase = insertAddressUseCase;
        }

        [HttpPost]
        public async Task InsertAddress(List<Address> address)
        {
            await _insertAddressUseCase.InsertAddress(address);
        }

    }
}
