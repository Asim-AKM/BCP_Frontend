namespace BCP_BL.Models.Response.StockStatus
{
    public class StockStatusResponse
    {
        public int Available { get; set; }

        public int Reserved { get; set; }

        public int Expired { get; set; }
    }
}