using BCP_BL.AdminService.StockStatus.Interface;
using BCP_BL.Models.Response.StockStatus;
using System.Net.Http.Json;

namespace BCP_BL.AdminService.StockStatus.Implementation
{
    public class StockStatusService(HttpClient _client) : IStockStatusService
    {
        public async Task<StockStatusResponse> GetStockStatusAsync()
        {
            var response = await _client.GetAsync("api/stock-status/stock-status");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StockStatusResponse>()
                           ?? new StockStatusResponse();
        }
    }
}