using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    public class EntralinkTimer : DelayTimer
    {
        public Int32 SecondaryCalibration { get; set; }

        public EntralinkTimer(Int32 calibration, Int32 secondaryCalibration, Int32 targetDelay, Int32 targetSecond, ConsoleType consoleType, Int32 minLength) : base(calibration, targetDelay, targetSecond, consoleType, minLength)
        {
            SecondaryCalibration = secondaryCalibration;

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        //overriden methods
        protected TimeSpan GetStage(Int32 stage)
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
