using ClientManager.Domain.Output;
using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IDeleteClientUseCase
    {
        Task DeleteClient(Guid id, IErrorActionResultPresenter<string> presenter);
    }
}
