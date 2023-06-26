using AppealManager.Application.Services;
using AppealManager.Application.Utilities.AppealUtilities;
using AppealManager.Application.Utilities.RKKUtilities;
using Microsoft.Extensions.DependencyInjection;

namespace AppealManager.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddSingleton<IRKKParser, RKKParser>()
                .AddSingleton<IRKKReader, RKKReader>()
                .AddSingleton<IAppealParser, AppealParser>()
                .AddSingleton<IAppealReader, AppealReader>()
                .AddSingleton<IAppealManagerService, AppealManagerService>()
                .AddSingleton<RKKStatisticsService>();

            return services;
        }
    }
}
