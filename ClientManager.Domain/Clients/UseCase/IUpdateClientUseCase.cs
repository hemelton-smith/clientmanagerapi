using ClientManager.Domain.Output;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IUpdateClientUseCase
    {
        Task UpdateClient(AddClientRequest client, IErrorActionResultPresenter<string> presenter);
    }
}
