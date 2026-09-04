using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.Models.Response;
using System.Net.Http.Json;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Implementation
{
    internal class StockStatusService(HttpClient _client) : IStockStatusService
    {
        public async Task<StockStatusResponse> GetStockStatusAsync()
        {
            var response = await _client.GetAsync("api/center-dashboard/stock-status");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<StockStatusResponse>()
                           ?? new StockStatusResponse();
        }
    }
}