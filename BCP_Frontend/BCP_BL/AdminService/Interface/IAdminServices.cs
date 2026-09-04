using BCP_BL.Models;
using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.AdminService.Interface
{
    public interface IAdminServices
    {
        Task<ApiResponse<List<GetAllBloodCentersResponse>>> GetAll();
        Task<ApiResponse<string>> UpdateStatus(UpdateBloodCenterRequest updateRequest);
    }
}
