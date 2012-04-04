using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    class EntralinkTimer : DelayTimer
    {
        public Int32 SecondaryCalibration { get; set; }

        //overriden methods
        public override TimeSpan GetLength(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return base.GetStage(0).Add(new TimeSpan(0, 0, 0, 0, 250));
                case 1:
                    return base.GetStage(1).Subtract(new TimeSpan(0, 0, 0, 0, SecondaryCalibration));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
    }
}
