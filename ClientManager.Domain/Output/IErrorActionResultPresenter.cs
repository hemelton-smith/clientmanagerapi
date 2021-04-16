using Microsoft.AspNetCore.Mvc;

namespace ClientManager.Domain.Output
{
    public interface IErrorActionResultPresenter<in TError> : IErrorPresenter<TError>
    {
        public IActionResult Render();
    }
}