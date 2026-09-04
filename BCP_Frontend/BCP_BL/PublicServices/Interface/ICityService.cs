using BCP_BL.Models;

namespace BCP_BL.PublicServices.Interface
{
    public interface ICityService
    {
        Task<List<GetAllCityResponse>> GetByProvinceIdAsync(Guid provinceId);
    }
}