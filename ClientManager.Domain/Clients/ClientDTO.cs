using System;

namespace ClientManager.Domain.Clients
{
    public class ClientDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
    }
}
