using System;

namespace Sales.Domain.Output
{
    public class PresenterException : Exception
    {
        public PresenterException(string message) : base(message)
        {
        }
    }
}
