using BCP_BL.AdminService.StockMatrix.Interface;
using BCP_BL.Models.Response.StockMatrix;
using System.Net.Http.Json;

namespace BCP_BL.AdminService.StockMatrix.Implementation
{
    public class StockMatrixService(HttpClient _client) : IStockMatrixService
    {
        public async Task<List<StockMatrixResponse>> GetStockMatrixAsync()
        {
            var response = await _client.GetAsync("api/stock-matrix/stock-matrix");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<StockMatrixResponse>>()
                           ?? new List<StockMatrixResponse>();
        }
    }
}