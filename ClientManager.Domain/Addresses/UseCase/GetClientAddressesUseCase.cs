using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using Sales.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public class GetClientAddressesUseCase : IGetClientAddressesUseCase
    {
        private readonly IAddressGateway _addressGateway;
        public GetClientAddressesUseCase(IAddressGateway addressGateway)
        {
            _addressGateway = addressGateway;
        }
        public async Task GetClientAddresses(Guid clientId, ISuccessOrErrorActionResultPresenter<List<Address>, ErrorDto> presenter)
        {
           var clientAddresses = await _addressGateway.GetClientAddresses(clientId);

            if(clientAddresses.Count > 0)
            {
                presenter.Success(clientAddresses);
            }
            else
            {
                presenter.Error(new ErrorDto
                {
                    Message = "No client addresses found"
                }); ;
            }
        }
    }
}
