using ClientManager.Domain.Output;
using Microsoft.Extensions.DependencyInjection;
using Sales.Domain.Output;

namespace ClientManager.Web.Main.IoCConfigs
{
    public static class PresenterIoCExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped(typeof(ISuccessOrErrorActionResultPresenter<,>), typeof(SuccessOrErrorRestPresenter<,>));
            services.AddScoped(typeof(IErrorActionResultPresenter<>), typeof(ErrorRestPresenter<>));

            return services;
        }
    }
}
