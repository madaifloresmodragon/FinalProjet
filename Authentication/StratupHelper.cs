using Authentication.DataAccess.Interfaces;
using Authentication.DataAccess.Repositories;
using Authentication.Services;
using Authentication.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication
{
    public class StratupHelper
    {
        public static void ResisterTypes(IServiceCollection services) 
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
        }

    }
}
