using ClientManager.Domain.Output;
using Sales.Domain.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientManager.Domain.Clients.UseCase
{
    public interface IGetAllClientsUseCase
    {
        Task Execute(ISuccessOrErrorActionResultPresenter<List<Client>, ErrorDto> presenter);
    }
}
