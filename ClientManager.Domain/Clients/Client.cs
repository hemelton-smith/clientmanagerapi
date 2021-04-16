using System;

namespace ClientManager.Domain.Clients
{
    public class Client
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public string CellNumber { get; set; }
        public string WorkNumber { get; set; }
    }

}
