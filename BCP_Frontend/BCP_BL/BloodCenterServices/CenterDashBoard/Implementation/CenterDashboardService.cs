using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.Models.Response;
using System.Net.Http.Json;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Implementation
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