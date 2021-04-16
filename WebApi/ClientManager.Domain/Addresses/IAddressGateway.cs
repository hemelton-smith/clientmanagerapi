using ClientManager.Domain.Clients;
using ClientManager.Domain.Output;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses
{
    public interface IAddressGateway
    {
        Task InsertAddress(List<Address> address);
        Task DeleteAddress(Guid clientId);
        Task<List<Address>> GetClientAddresses(Guid clientId);
        Task UpdateClientAddresses(List<Address> address);

    }
}
