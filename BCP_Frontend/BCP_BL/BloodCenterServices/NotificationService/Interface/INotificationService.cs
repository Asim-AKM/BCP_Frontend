using BCP_BL.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.BloodCenterServices.NotificationService.Interface
{
    public interface INotificationService
    {
        Task<List<NotificationsRequest>> GetAllNotifications();
    }
}
