using BCP_BL.BloodCenterServices.NotificationService.Interface;
using BCP_BL.Models;
using BCP_BL.Models.Response;
using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.BloodCenterServices.NotificationService.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly HttpClient _httpClient;
        public NotificationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<NotificationsRequest>> GetAllNotifications()
        {
            var response = await _httpClient.GetAsync("https://localhost:7251/api/GetAllNotification/GetAll");

            if (!response.IsSuccessStatusCode)
            {
                return new List<NotificationsRequest>();
            }

            var result = await response.Content.ReadFromJsonAsync<List<NotificationsRequest>>();

            return result ?? new List<NotificationsRequest>();
        }
    }
}
