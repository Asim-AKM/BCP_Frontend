using BCP_BL.Models;
using BCP_BL.PublicServices.Interface;
using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.PublicServices.Implementation
{
    public class EmergencyBroadcastService : IEmergencyBroadcastService
    {
        private readonly HttpClient _httpClient;
        public EmergencyBroadcastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<string>> SendBroadcastAsync(EmergencyBroadcastRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7251/api/EmergencyBroadcast/Create_EmergencyBroadcast", request);
            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
            return result ?? new ApiResponse<string> { IsSuccess = false, ErrorMessage = "No response from server" };
        }
    }
}
