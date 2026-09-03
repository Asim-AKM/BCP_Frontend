using BCP_BL.AuthenticationServices.Implementation;
using BCP_BL.AuthenticationServices.interfaces;
using BCP_BL.PublicServices.Implementation;
using BCP_BL.PublicServices.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BCP_BL.DI
{
    public static class ServicesRegisters
    {

        public static IServiceCollection ServiceConfig(this IServiceCollection service) => service
          .AddScoped<IAuthService, AuthService>()
            .AddScoped<HttpClient>()
            .AddScoped<IEmergencyBroadcastService, EmergencyBroadcastService>();
    }
}
