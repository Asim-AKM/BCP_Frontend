using BCP_BL.Models;

namespace BCP_BL.PublicServices.Interface
{
    public interface IProvinceService
    {
        Task<List<GetAllProvinceResponse>> GetAllAsync();
    }
}