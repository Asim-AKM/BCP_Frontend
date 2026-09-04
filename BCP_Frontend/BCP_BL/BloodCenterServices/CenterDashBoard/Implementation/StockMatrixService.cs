using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.Models.Response;
using System.Net.Http.Json;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Implementation
{
    public class StockMatrixService(HttpClient _client) : IStockMatrixService
    {
        public async Task<List<StockMatrixResponse>> GetStockMatrixAsync()
        {
            var response = await _client.GetAsync("api/center-dashboard/stock-matrix");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<StockMatrixResponse>>()
                           ?? new List<StockMatrixResponse>();
        }
    }
}