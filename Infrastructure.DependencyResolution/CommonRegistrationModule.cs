using Core.Service;
using Core.Interface;

using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolution
{
    public static class CommonRegistrationModule
    {
        public static void AddCommonModules(this IServiceCollection services)
        {
            services.AddSingleton<ISqlService, SqlService>();
        }
    }
}
