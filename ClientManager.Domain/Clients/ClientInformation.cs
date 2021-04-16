using System;

namespace ClientManager.Domain.Clients
{
    public class ClientInformation
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string code { get; set; }
        public string Type { get; set; }
    }
}
