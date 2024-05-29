using Microsoft.Extensions.DependencyInjection;
using NextCBS.Bank.Intercom.Service;

namespace NextCBS.Bank.Intercom
{
    public static class DiConfig
    {
        public static IServiceCollection UserIntercomDi(this IServiceCollection services)
        {
            services.AddScoped<IdentityIntercomService>();
            return services;
        }
    }
}
