using ClientManager.Domain.Output;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IExportClientInformationUseCase
    {
        Task GetClientsInformation(IErrorActionResultPresenter<string> presenter);
    }
}
