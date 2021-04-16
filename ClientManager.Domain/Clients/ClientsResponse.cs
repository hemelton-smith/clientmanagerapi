using ClientManager.Domain.Addresses;
using System.Collections.Generic;

namespace ClientManager.Domain.Clients
{
    public class ClientsResponse
    {
        public ClientDTO Client { get; set; }
        public List<AddressDTO> Addresses { get; set; }
    }
}
