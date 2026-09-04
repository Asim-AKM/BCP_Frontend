using BCP_BL.AdminService.Interface;
using BCP_BL.Models;
using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BCP_BL.AdminService.Implemantation
{
    public class AdminServices : IAdminServices
    {
        private readonly HttpClient _httpClient;

        public AdminServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7251/");
        }

        public async Task<ApiResponse<List<GetAllBloodCentersResponse>>> GetAll()
        {
            try
            {

                var centers = await _httpClient.GetFromJsonAsync<List<GetAllBloodCentersResponse>>("api/BloodCenter/GetAll");

                return new ApiResponse<List<GetAllBloodCentersResponse>>
                {
                    IsSuccess = true,
                    Data = centers ?? new List<GetAllBloodCentersResponse>()
                };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<GetAllBloodCentersResponse>>
                {
                    IsSuccess = false,
                    ErrorMessage = $"Network error: {ex.Message}"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<GetAllBloodCentersResponse>>
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponse<string>> UpdateStatus(UpdateBloodCenterRequest updateRequest)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/BloodCenter/BloodCenter", updateRequest);
                var content = await response.Content.ReadAsStringAsync();
                return new ApiResponse<string> {Data = content};
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>{ErrorMessage = ex.Message};
            }
        }
    }
}