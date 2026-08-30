using BCP_BL.AdminService.CenterDashBoard.Interface;
using BCP_BL.Models.Response.CenterDashBoard;
using System.Net.Http.Json;

namespace BCP_BL.AdminService.CenterDashBoard.Implementation
{
    public class CenterDashboardService(HttpClient _client) : ICenterDashboardService
    {
        public async Task<CenterDashboardStatisticsResponse> GetStatisticsAsync()
        {
            var response = await _client.GetAsync("api/center-dashboard/statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CenterDashboardStatisticsResponse>()
                          ?? new CenterDashboardStatisticsResponse();
        }
    }
}