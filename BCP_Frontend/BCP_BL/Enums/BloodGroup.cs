using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Enums
{
    public enum BloodGroup
    {
        APositive ,
        ANegative,
        BPositive,
        BNegative ,
        ABPositive ,
        ABNegative ,
        OPositive ,
        ONegative
    }
    public enum BloodRequestStatus
    {
        Pending = 1,
        Accepted = 2,
        Dispatched = 3,
        Rejected = 4,
        Cancelled = 5
    }
    public enum BloodComponentType
    {
        WholeBlood ,
        PackedRBC ,
        Plasma ,
        Platelets ,
        Cryoprecipitate
    }
}