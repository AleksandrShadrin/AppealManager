using AppealManager.Application.AppealUtilities;
using AppealManager.Application.RKKUtilities;
using AppealManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AppealManager.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddSingleton<IRKKReader, RKKReader>()
                .AddSingleton<IAppealReader, AppealReader>()
                .AddSingleton<IAppealManagerService, AppealManagerService>();

            return services;
        }

    }
}
