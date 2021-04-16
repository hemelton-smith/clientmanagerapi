using ClientManager.Domain.Output;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IAddClientUseCase
    {
        Task AddClient(AddClientRequest clientResponse, IErrorActionResultPresenter<string> presenter);
    }
}
