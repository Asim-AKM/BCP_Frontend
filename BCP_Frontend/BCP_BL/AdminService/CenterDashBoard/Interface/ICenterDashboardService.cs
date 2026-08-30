using BCP_BL.Models.Response.CenterDashBoard;

namespace BCP_BL.AdminService.CenterDashBoard.Interface
{
    public interface ICenterDashboardService
    {
        Task<CenterDashboardStatisticsResponse> GetStatisticsAsync();
    }
}