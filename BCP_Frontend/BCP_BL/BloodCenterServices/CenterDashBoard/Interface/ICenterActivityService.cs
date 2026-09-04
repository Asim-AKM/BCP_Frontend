using BCP_BL.Models.Response;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Interface
{
    public interface ICenterActivityService
    {
        Task<CenterActivityResponse> GetActivityStatisticsAsync();
    }
}