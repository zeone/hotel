using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel.Helpers
{
    public static class DecimalHelper
    {
        public static string ToShortString(this decimal value)
        {
            return $"{value:0.##}";
        }
    }
}