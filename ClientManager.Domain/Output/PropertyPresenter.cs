namespace Sales.Domain.Output
{
    public class PropertyPresenter<TSuccess, TError> : ISuccessOrErrorPresenter<TSuccess, TError>
    {
        public TError ErrorResult { get; private set; }
        public TSuccess SuccessResult { get; private set; }

        public void Error(TError error)
        {
            ErrorResult = error;
        }

        public void Success(TSuccess successResult)
        {
            SuccessResult = successResult;
        }
    }
}
