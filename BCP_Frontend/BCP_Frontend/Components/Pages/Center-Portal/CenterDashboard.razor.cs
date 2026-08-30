using BCP_BL.AdminService.CenterActivity.Interface;
using BCP_BL.AdminService.CenterDashBoard.Interface;
using BCP_BL.AdminService.StockMatrix.Interface;
using BCP_BL.AdminService.StockStatus.Interface;
using BCP_BL.Models.Response.CenterActivity;
using BCP_BL.Models.Response.CenterDashBoard;
using BCP_BL.Models.Response.StockMatrix;
using BCP_BL.Models.Response.StockStatus;
using Microsoft.AspNetCore.Components;

namespace BCP_Frontend.Components.Pages.Center_Portal
{
    public partial class CenterDashboard
    {
        [Inject]
        private ICenterDashboardService DashboardService { get; set; } = default!;

        [Inject]
        private IStockMatrixService StockMatrixService { get; set; } = default!;

        [Inject]
        private IStockStatusService StockStatusService { get; set; } = default!;

        [Inject]
        private ICenterActivityService CenterActivityService { get; set; } = default!;

        private CenterDashboardStatisticsResponse? Statistics;
        private List<StockMatrixResponse> StockMatrix = new();
        private StockStatusResponse? StockStatus;
        private CenterActivityResponse? centerActivity;




        protected override async Task OnInitializedAsync()
        {
            Statistics = await DashboardService.GetStatisticsAsync();

            StockMatrix = await StockMatrixService.GetStockMatrixAsync();

            StockStatus = await StockStatusService.GetStockStatusAsync();

            centerActivity = await CenterActivityService.GetActivityStatisticsAsync();
        }

        private string GetStockStatusClass(string status)
        {
            return status switch
            {
                "Critical" => "text-red-400 bg-red-500/10",
                "Low Stock" => "text-amber-400 bg-amber-500/10",
                "Sufficient" => "text-emerald-400 bg-emerald-500/10",
                _ => "text-slate-400 bg-slate-500/10"
            };
        }
    }
}