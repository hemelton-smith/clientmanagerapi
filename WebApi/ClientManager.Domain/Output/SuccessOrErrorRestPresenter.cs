using Microsoft.AspNetCore.Mvc;

namespace Sales.Domain.Output
{
    public class SuccessOrErrorRestPresenter<TSuccess, TError> : ISuccessOrErrorActionResultPresenter<TSuccess, TError>
    {
        private TError _error;
        private TSuccess _success;

        public void Error(TError error)
        {
            _error = error;
        }

        public void Success(TSuccess successResult)
        {
            _success = successResult;
        }

        public IActionResult Render()
        {
            if (HasError() && HasSuccess())
            {
                throw CreateMultipleResultsException();
            }

            if (HasError())
            {
                return new BadRequestObjectResult(_error);
            }

            if (!HasSuccess())
            {
                return new BadRequestResult();
            }

            return new OkObjectResult(_success);
        }

        private bool HasSuccess()
        {
            return _success != null;
        }

        private bool HasError()
        {
            return _error != null;
        }

        private PresenterException CreateMultipleResultsException()
        {
            return new PresenterException($"{nameof(SuccessOrErrorRestPresenter<TSuccess, TError>)} was unable to render because it was given both a success and error result.");
        }
    }
}
