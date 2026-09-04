namespace BCP_BL.Models.Response
{
    public class CenterDashboardStatisticsResponse
    {
        public int TotalUnitsInStock { get; set; }
        
        public int TodaysDispatches { get; set; }
        
        public int PendingRequests { get; set; }
        
        public int RegisteredDonors { get; set; }
    }
}