namespace BCP_BL.Models
{
    public class GetAllCityResponse
    {
        public Guid Id { get; set; }
        
        public Guid ProvinceID { get; set; }
        
        public string City_Name { get; set; } = string.Empty;
        
        public bool IsActive { get; set; }
    }
}