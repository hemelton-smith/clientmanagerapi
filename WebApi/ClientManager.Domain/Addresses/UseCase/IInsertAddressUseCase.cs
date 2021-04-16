using ClientManager.Domain.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public interface IInsertAddressUseCase
    {
        Task InsertAddress(List<Address> address);
    }
}
