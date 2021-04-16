using System;

namespace ClientManager.Domain.Clients
{
    public class Address
    {
        public Guid Id { get; set; } 
        public Guid ClientId { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Code { get; set; }
        public int Type { get; set; }

    }
}