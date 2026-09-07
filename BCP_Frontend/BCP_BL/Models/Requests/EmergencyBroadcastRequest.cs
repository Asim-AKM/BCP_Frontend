using BCP_BL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Models
{
    public class EmergencyBroadcastRequest
    {
        public Guid BloodRequestId { get; set; }
        [Required(ErrorMessage = "Patient name is required.")]
        public string PatientName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please select a blood group.")]
        public BloodGroup BloodGroup { get; set; }
        public Guid Id { get; set; }
        public Guid ProvinceID { get; set; }
        [Required(ErrorMessage = "Units count is required.")]
        [Range(1, 20, ErrorMessage = "Units must be between 1 and 20.")]
        public int UnitsRequired { get; set; }
        [Required(ErrorMessage = "Please select an urgency level.")]
        public string UrgencyLevel { get; set; } = string.Empty;
        [Required(ErrorMessage = "Attendant contact number is required.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string Contact { get; set; } = string.Empty;

        public string? CaseDescription { get; set; }
        public BloodRequestStatus BloodRequestStatus { get; set; }
    }
}
