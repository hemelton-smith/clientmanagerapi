using ClientManager.Domain.Clients;
using ClientManager.Domain.Clients.UseCase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientManager.Web.Api.Clients
{
    [ApiController]
    [Route("getclientbyid")]
    public class GetClientByIdController : ControllerBase
    {
        private readonly IGetClientByIdUseCase _getClientByIdUseCase;

        public GetClientByIdController(IGetClientByIdUseCase getClientByIdUseCase)
        {
            _getClientByIdUseCase = getClientByIdUseCase;
        }

        [HttpGet]
        public async Task<Client> GetClientById(Guid id)
        {
           return await _getClientByIdUseCase.GetClientById(id);
        }
    }
}
