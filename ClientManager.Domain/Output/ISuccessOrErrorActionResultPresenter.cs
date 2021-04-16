using Microsoft.AspNetCore.Mvc;

namespace Sales.Domain.Output
{
    public interface ISuccessOrErrorActionResultPresenter<in TSuccess, in TError> : ISuccessOrErrorPresenter<TSuccess, TError>
    {
        public IActionResult Render();
    }
}

