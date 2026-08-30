using BCP_BL.Models.Response.CenterActivity;

namespace BCP_BL.AdminService.CenterActivity.Interface
{
    public interface ICenterActivityService
    {
        Task<CenterActivityResponse> GetActivityStatisticsAsync();
    }
}
