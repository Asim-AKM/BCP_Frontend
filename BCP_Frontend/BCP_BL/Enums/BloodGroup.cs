using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP_BL.Enums
{
    public enum BloodGroup
    {
        APositive = 1,
        ANegative = 2,
        BPositive = 3,
        BNegative = 4,
        ABPositive = 5,
        ABNegative = 6,
        OPositive = 7,
        ONegative = 8
    }
    public enum BloodRequestStatus
    {
        Pending = 1,
        Accepted = 2,
        Dispatched = 3,
        Rejected = 4,
        Cancelled = 5
    }
}
