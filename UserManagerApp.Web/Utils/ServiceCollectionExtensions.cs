

using App.Security.TokenSecurity;
using App.Services.Contracts;
using UserManagerApp.Services.PersonaUser;
using UserManagerApp.Services.User;

namespace BancoPacifico.Web.Utils
{
    public static class ServiceCollectionExtensions
    {
        
        public static void AddUserManagerAppServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPersonUser, PersonUser>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserSession, UserSession>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
        }



    }
}
