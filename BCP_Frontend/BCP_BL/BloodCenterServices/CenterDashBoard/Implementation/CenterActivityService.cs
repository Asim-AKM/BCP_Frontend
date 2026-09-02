using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.Models.Response;
using System.Net.Http.Json;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Implementation
{
    public class CenterActivityService(HttpClient _client) : ICenterActivityService
    {
        public async Task<CenterActivityResponse> GetActivityStatisticsAsync()
        {
            var response = await _client.GetAsync("api/center-dashboard/activity-statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CenterActivityResponse>()
           ?? new CenterActivityResponse();
        }
    }
}