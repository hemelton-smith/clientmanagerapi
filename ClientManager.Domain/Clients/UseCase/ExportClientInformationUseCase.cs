using ClientManager.Domain.Addresses;
using ClientManager.Domain.Output;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public class ExportClientInformationUseCase : IExportClientInformationUseCase
    {
        private readonly IClientGateway _clientGateway;

        public ExportClientInformationUseCase(IClientGateway clientGateway)
        {
            _clientGateway = clientGateway;
        }
        public async Task GetClientsInformation(IErrorActionResultPresenter<string> presenter)
        {
            var clientsInformation = await _clientGateway.GetClientsInformation();
            var clientdDictionary = new Dictionary<Guid, ClientsResponse>();

            foreach (var client in clientsInformation)
            {
                var isClientFound = clientdDictionary.TryGetValue(client.Id, out _);
                if (isClientFound)
                {
                    clientdDictionary[client.Id].Addresses.Add(new AddressDTO
                    {
                        Street = client.Street,
                        Town = client.Town,
                        Code = client.code,
                        Type = $"{client.Type} Address"
                    });
                }
                else
                {
                    var clientResponse = new ClientsResponse
                    {
                        Client = new ClientDTO
                        {
                            Id = client.Id,
                            FirstName = client.FirstName,
                            LastName = client.LastName,
                            Gender = client.Gender
                        },
                        Addresses = new List<AddressDTO>
                       {
                           new AddressDTO
                           {
                               Street=client.Street,
                               Town=client.Town,
                               Code=client.code,
                               Type=$"{client.Type} Address"
                           }
                       }
                    };
                    clientdDictionary.Add(client.Id, clientResponse);
                }
            }

            await ExportClients(clientdDictionary);

            if (clientdDictionary.Values.Count == 0)
            {
                presenter.Error("No clients found");
            }
        }

        private async Task ExportClients(Dictionary<Guid, ClientsResponse> clientsDictonary)
        {
            var clients = JsonConvert.SerializeObject(clientsDictonary.Values.Select(clientResponse => clientResponse).ToList());
            var filePath = AppDomain.CurrentDomain.BaseDirectory;

            using var writer = new StreamWriter($"{filePath}/clients/clients-{DateTime.Now.ToFileTime()}.txt");
            await writer.WriteAsync(clients);
        }
    }
}
