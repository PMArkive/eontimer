using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer.Timers
{
    public class NullTimer : ITimer
    {
        public List<TimeSpan> Stages
        {
            get { return new List<TimeSpan>(); }
        }

        public Int32 Calibrate(Int32 result)
        {
            return 0;
        }
        public Int32 GetMinutesBeforeTarget()
        {
            return 0;
        }
    }
}
