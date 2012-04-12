using System;
using System.Collections.Generic;
using System.Text;
using System

namespace EonTimer.Utilities.Helpers
{
    public static class Extensions
    {
        public static void Set(this Int32 n, String str)
        {
            var n1 = 0;
            n = Int32.TryParse(str, out n1) ? n1 : n;
        }
    }
}
