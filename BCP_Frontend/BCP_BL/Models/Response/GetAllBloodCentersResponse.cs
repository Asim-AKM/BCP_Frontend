using BCP_BL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Models
{
    public class GetAllBloodCentersResponse
    {

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string RegistrationNumber { get; set; }
        public Guid CityId { get; set; }
        public required string Address { get; set; }
        public required string ContactPhone { get; set; }
        public required BloodCenterStatus Status { get; set; }
        public required string EmergencyPhone { get; set; }
        public required string ImageUrl { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }

    }
    public class UpdateBloodCenterRequest
    {
        public Guid Id { get; set; }                    
        public required string Name { get; set; }      
        public required string RegistrationNumber { get; set; } 
        public Guid CityId { get; set; }               
        public required string Address { get; set; }   
        public required string ContactPhone { get; set; } 
        public required string EmergencyPhone { get; set; } 
        public required BloodCenterStatus Status { get; set; }
        public bool IsVerified { get; set; }            
        public bool IsActive { get; set; } 
    }
}
