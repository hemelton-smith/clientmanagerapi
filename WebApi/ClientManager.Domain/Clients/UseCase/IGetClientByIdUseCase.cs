using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IGetClientByIdUseCase
    {
        Task<Client> GetClientById(Guid guid);
    }
}
