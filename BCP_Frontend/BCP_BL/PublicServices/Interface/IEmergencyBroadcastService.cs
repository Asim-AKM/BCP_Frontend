using BCP_BL.Models;
using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.PublicServices.Interface
{
    public interface IEmergencyBroadcastService
    {
        Task<ApiResponse<string>> SendBroadcastAsync(EmergencyBroadcastRequest request);
    }
}
