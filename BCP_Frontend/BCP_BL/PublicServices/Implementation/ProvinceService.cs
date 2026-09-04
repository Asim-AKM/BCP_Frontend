using BCP_BL.Models;
using BCP_BL.PublicServices.Interface;
using System.Net.Http.Json;

namespace BCP_BL.PublicServices.Implementation
{
    public class ProvinceService(HttpClient _client) : IProvinceService
    {
        public async Task<List<GetAllProvinceResponse>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<GetAllProvinceResponse>>("api/provinces/GetAll") ?? new();
        }
    }
}