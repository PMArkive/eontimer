using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer.Timers
{
    public class CustomTimer : ITimer
    {
        public List<TimeSpan> Stages { get; protected set; }

        public CustomTimer(Int32[] stages)
        {
            Stages = new List<TimeSpan>();

            foreach(var stage in stages)
                Stages.Add(new TimeSpan(0, 0, 0, 0, stage));
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
