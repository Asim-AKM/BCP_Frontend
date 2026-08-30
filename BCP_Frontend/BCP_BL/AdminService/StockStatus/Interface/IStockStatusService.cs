using BCP_BL.Models.Response.StockStatus;

namespace BCP_BL.AdminService.StockStatus.Interface
{
    public interface IStockStatusService
    {
        Task<StockStatusResponse> GetStockStatusAsync();
    }
}