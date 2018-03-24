using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Enums
{
    public enum ReservationStatus
    {
        ReservedByUser = 1,
        ReservedByAdmin = 2,
        ReserverBySystem = 3,
        Canceled = 4
    }
}