using Microsoft.AspNetCore.Mvc;

namespace ClientManager.Domain.Output
{
    public class ErrorPresenter<T> : IErrorActionResultPresenter<T>
    {
        private T _error;

        public void Error(T error)
        {
            _error = error;
        }

        public IActionResult Render()
        {
            if (_error == null) return new OkResult();

            return new BadRequestObjectResult(_error);
        }
    }
}
