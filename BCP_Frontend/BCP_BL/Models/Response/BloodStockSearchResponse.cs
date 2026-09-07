using BCP_BL.Enums;

namespace BCP_BL.Models.Response
{
    public class BloodStockSearchResponse
    {
        public Guid InventoryId { get; set; }
        
        public string? BloodCenterName { get; set; }
        
        public string? BloodGroup { get; set; }
        
        public BloodComponentType ComponentType { get; set; }
        
        public int QuantityInUnits { get; set; }
        
        public DateTime ExpiryDate { get; set; }
    }
}