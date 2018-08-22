using System;
using System.Collections.Generic;
using System.Text;

namespace CommunityBot.Features.DnDHelper.Models
{
    public class NumberRange
    {
        public int LowEnd { get; set; }
        public int HighEnd { get; set; }

        public static bool operator ==(NumberRange obj1, int obj2)
        {
            if (obj2 >= obj1.LowEnd && obj2 <= obj1.HighEnd)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(NumberRange obj1, int obj2)
        {
            if (obj2 >= obj1.LowEnd && obj2 <= obj1.HighEnd)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public NumberRange(int low, int high)
        {
            LowEnd = low;
            HighEnd = high;
        }
    }
}
