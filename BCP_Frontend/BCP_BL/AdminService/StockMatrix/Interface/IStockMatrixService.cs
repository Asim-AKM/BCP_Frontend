using BCP_BL.Models.Response.StockMatrix;

namespace BCP_BL.AdminService.StockMatrix.Interface
{
    public interface IStockMatrixService
    {
        Task<List<StockMatrixResponse>> GetStockMatrixAsync();
    }
}