using Meeting.Module.Services;
using NextCBS.Bank.Contracts;
using NextCBS.Bank.Data.Repositories;
using NextCBS.Bank.Module.IRepositories;

namespace NextCBS.Bank.Api
{
    public static class DiConfig
    {
        public static IServiceCollection ConfiguredServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddScoped<IParameterRepository, ParameterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserPermissionRepository, UserPermissionReporitory>();

            services.AddScoped<UserService>();

            services.AddScoped<IMicroServiceMeta, MicroServiceMeta>();


            return services;
        }
    }
}
