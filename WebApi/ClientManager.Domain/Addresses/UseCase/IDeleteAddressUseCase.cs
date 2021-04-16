using ClientManager.Domain.Output;
using System;
using System.Threading.Tasks;

namespace ClientManager.Domain.Addresses.UseCase
{
    public interface IDeleteAddressUseCase
    {
        Task DeleteAddress(Guid clientId, IErrorActionResultPresenter<string> presenter);
    }
}
