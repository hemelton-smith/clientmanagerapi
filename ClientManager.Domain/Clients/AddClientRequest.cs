using System.Collections.Generic;

namespace ClientManager.Domain.Clients
{
    public class AddClientRequest
    {
        public Client Client { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
