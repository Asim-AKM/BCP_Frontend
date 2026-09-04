using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Shared
{
    public enum Role
    {
        SuperAdmin = 1,
        CenterAdmin = 2,
        Donor = 3
    }

    public enum SubscriptionStatus
    {
        Active = 1,
        Expired = 2,
        Cancelled = 3,
        Pending = 4
    }

    public enum InventoryStatus
    {
        Available = 1,
        Reserved = 2,
        Issued = 3,
        Expired = 4,
        Discarded = 5
    }

    public enum BloodComponentType
    {
        WholeBlood = 1,
        PackedRBC = 2,
        Plasma = 3,
        Platelets = 4,
        Cryoprecipitate = 5
    }
    public enum BloodCenterStatus
    {
        Active = 0,
        Pending = 1,
        Approved = 2,
        Rejected = 3,
        Suspended = 4,
        Freeze = 5,
        UnFreeze = 6,
    }
}