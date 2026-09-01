using BCP_BL.AuthenticationServices.Implementation;
using BCP_BL.AuthenticationServices.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BCP_BL.DI
{
    public static class ServicesRegisters
    {

        public static IServiceCollection ServiceConfig(this IServiceCollection service) => service
          .AddScoped<IAuthService, AuthService>()
            .AddScoped<HttpClient>();
    }
}
