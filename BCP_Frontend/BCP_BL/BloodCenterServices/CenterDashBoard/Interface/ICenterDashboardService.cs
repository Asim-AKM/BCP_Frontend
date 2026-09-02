using BCP_BL.Models.Response;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Interface
{
    public interface ICenterDashboardService
    {
        Task<CenterDashboardStatisticsResponse> GetStatisticsAsync();
    }
}