using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuffAndThings.Enums
{
    public enum OrderStatus
    {
        None = 0,
        Created = 1,
        Pay = 2,
        Separation = 3,
        InDelivery = 4,
        Finalized = 5,
        Canceled = 6,
        Error = 99
    }
}
