using ClientManager.Domain.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public class InsertAddressUseCase : IInsertAddressUseCase
    {
        private readonly IAddressGateway _addressGateway;

        public InsertAddressUseCase(IAddressGateway addressGateway)
        {
            _addressGateway = addressGateway;
        }
        public async Task InsertAddress(List<Address> address)
        {
            await _addressGateway.InsertAddress(address);
        }
    }
}
