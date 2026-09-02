using BCP_BL.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.BloodCenterServices.CenterDashBoard.Interface
{
    public interface IStockMatrixService
    {
        Task<List<StockMatrixResponse>> GetStockMatrixAsync();
    }
}
