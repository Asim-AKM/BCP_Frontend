using BCP_BL.Models.Response;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Interface
{
    public interface IBloodInventoryService
    {
        Task<List<BloodStockSearchResponse>> SearchBloodStockAsync(Guid cityId,string bloodGroup,int componentType);
    }
}