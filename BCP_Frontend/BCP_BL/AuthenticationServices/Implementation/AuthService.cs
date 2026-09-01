using BCP_BL.AuthenticationServices.interfaces;
using BCP_BL.Models;
using BCP_BL.Shared;
using System.Net.Http.Json;

namespace BCP_BL.AuthenticationServices.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<string>> LoginAsync(LoginUserRequest loginUserRequest)
        {

          var response= await _httpClient.PostAsJsonAsync("https://localhost:7251/api/Authentication/Login", loginUserRequest);

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();

           return result ?? new ApiResponse<string> { IsSuccess = false, ErrorMessage = "No response from server" };

        }
    }
}
