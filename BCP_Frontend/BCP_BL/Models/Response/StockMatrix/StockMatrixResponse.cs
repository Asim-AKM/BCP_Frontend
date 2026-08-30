namespace BCP_BL.Models.Response.StockMatrix
{
    public class StockMatrixResponse
    {
        public string BloodGroup { get; set; } = string.Empty;
        
        public int TotalUnits { get; set; }
        
        public string StockStatus { get; set; } = string.Empty;
    }
}