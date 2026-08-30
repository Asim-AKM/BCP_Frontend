using BCP_BL.AdminService.CenterActivity.Interface;
using BCP_BL.Models.Response.CenterActivity;
using System.Net.Http.Json;

namespace BCP_BL.AdminService.CenterActivity.Implementation
{
    public class CenterActivityService(HttpClient _client) : ICenterActivityService
    {
        public async Task<CenterActivityResponse> GetActivityStatisticsAsync()
        {
            var response = await _client.GetAsync("api/center-activity/activity-statistics");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CenterActivityResponse>()
           ?? new CenterActivityResponse();
        }
    }
}