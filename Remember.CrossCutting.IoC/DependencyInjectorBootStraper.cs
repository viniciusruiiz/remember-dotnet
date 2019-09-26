using Microsoft.Extensions.DependencyInjection;
using Remember.DAL.Repository;
using Remember.Domain.Interface.Repository;
using Remember.Domain.Interface.Service;
using Remember.Services.Services;

namespace Remember.CrossCutting.IoC
{
    public static class DependencyInjectorBootStraper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            ConfigureRepositories(services);
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            //services.AddSingleton<IMemoryLineService, MemoryLineService>();
            //services.AddSingleton<IMomentService, MomentService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            //services.AddSingleton<IMemoryLineRepository, MemoryLineRepository>();
            //services.AddSingleton<IMomentRepository, MomentRepository>();
        }
    }
}
