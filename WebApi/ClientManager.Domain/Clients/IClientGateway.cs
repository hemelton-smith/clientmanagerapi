using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients
{
    public interface IClientGateway
    {
        Task CreateClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(Guid ClientId);
        Task<List<Client>> GetAllClients();
        Task<Client> GetAllClientById(Guid ClientID);
        Task<List<ClientInformation>> GetClientsInformation();
    }
}
