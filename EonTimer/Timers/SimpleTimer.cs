using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    class SimpleTimer : ITimer
    {
        public Int32 Calibration { get; set; }
        public Int32 TargetSecond { get; set; }

        public TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return new TimeSpan(0, 0, 0, 0, (TargetSecond * 1000 + Calibration));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
        public Int32 Calibrate(Int32 result)
        {
            if (result == TargetSecond)
                return 0;
            else if (result > TargetSecond)
                return ((TargetSecond - result + 1) * 60 - 30);
            else
                return ((TargetSecond - result - 1) * 60 + 30);
        }
    }
}
