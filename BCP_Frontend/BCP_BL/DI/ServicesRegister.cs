using BCP_BL.AdminService.Implemantation;
using BCP_BL.AdminService.Interface;
using BCP_BL.AuthenticationServices.Implementation;
using BCP_BL.AuthenticationServices.interfaces;
<<<<<<< HEAD
using BCP_BL.BloodCenterServices.CenterDashBoard.Implementation;
using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.PublicServices.Implementation;
using BCP_BL.PublicServices.Interface;
=======
>>>>>>> parent of c0db38b (Dynamic province/city dropdowns with API integration)
using Microsoft.Extensions.DependencyInjection;

namespace BCP_BL.DI
{
    public static class ServicesRegisters
    {

        public static IServiceCollection ServiceConfig(this IServiceCollection service) => service
          .AddScoped<IAuthService, AuthService>()
<<<<<<< HEAD
          
            .AddScoped<IEmergencyBroadcastService, EmergencyBroadcastService>()
            .AddScoped<IAdminServices, AdminServices>()
        #region Haroon Services
            .AddScoped<ICenterActivityService , CenterActivityService>()
            .AddScoped<ICenterDashboardService, CenterDashboardService>()
            .AddScoped<IStockStatusService, StockStatusService>()
            .AddScoped<IStockMatrixService, StockMatrixService>()
        #endregion
          
            
     
        #region Haroon Services
                .AddScoped<ICityService, CityService>()
                .AddScoped<IProvinceService, ProvinceService>();
        #endregion
=======
            .AddScoped<HttpClient>();
>>>>>>> parent of c0db38b (Dynamic province/city dropdowns with API integration)
    }
}
