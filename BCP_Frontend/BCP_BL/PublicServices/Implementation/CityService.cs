using BCP_BL.Models;
using BCP_BL.PublicServices.Interface;
using System.Net.Http.Json;

namespace BCP_BL.PublicServices.Implementation
{
    public class CityService(HttpClient _client) : ICityService
    {
        public async Task<List<GetAllCityResponse>> GetByProvinceIdAsync(Guid provinceId)
        {
            return await _client.GetFromJsonAsync<List<GetAllCityResponse>>($"api/cities/Province/{provinceId}") ?? new();
        }
    }
}