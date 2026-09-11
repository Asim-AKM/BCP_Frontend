using BCP_BL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Models.Response
{
    public class NotificationsRequest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string PatientName { get; set; } = string.Empty;
        public BloodGroup BloodGroup { get; set; }

        public int UnitRequired { get; set; }
        public string UrgencyLevel { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Guid? EmergencyBroadcastId { get; set; }

       
    }
}
