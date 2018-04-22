using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotel.Models;

namespace Hotel.Helpers
{
    public static class PriceHelper
    {
        public static decimal GetPrice(ApType type, int guestCount)
        {
            decimal price = 0M;
            if (guestCount >= 1 && type.OnePersonPrice != 0) price = type.OnePersonPrice;
            if (guestCount >= 2 && type.TwoPersonPrice != 0) price = type.TwoPersonPrice;
            if (guestCount >= 3 && type.ThreePersonPrice != 0) price = type.ThreePersonPrice;
            if (guestCount >= 4 && type.FourPersonPrice != 0) price = type.FourPersonPrice;
            return price;
        }
    }
}