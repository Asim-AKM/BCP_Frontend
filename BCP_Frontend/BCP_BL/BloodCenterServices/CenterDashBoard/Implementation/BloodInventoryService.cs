using BCP_BL.BloodCenterServices.CenterDashBoard.Interface;
using BCP_BL.Models.Response;
using System.Net.Http.Json;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Implementation
{
    public class BloodInventoryService(HttpClient _client) : IBloodInventoryService
    {
        public async Task<List<BloodStockSearchResponse>> SearchBloodStockAsync(Guid cityId, string bloodGroup, int componentType)
        {

            return await _client.GetFromJsonAsync<List<BloodStockSearchResponse>>(
             $"api/BloodInventory/SearchStock" +$"?cityId={cityId}" +$"&bloodGroup={Uri.EscapeDataString(bloodGroup)}" +$"&componentType={(int)componentType}") ?? new();
        }
    }
}