using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    public class EnhancedEntralinkTimer : EntralinkTimer
    {
        public Int32 StandardTargetSecond { get; set; }

        public EnhancedEntralinkTimer(Int32 calibration, Int32 secondaryCalibration, Int32 standardTargetSecond, Int32 targetDelay, Int32 entralinkTargetSecond, Consoles.ConsoleType consoleType, Int32 minLength)
            : base(calibration, secondaryCalibration, targetDelay, entralinkTargetSecond, consoleType, minLength)
        {
            StandardTargetSecond = standardTargetSecond;

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        protected new TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return base.GetStage(0).Add(new TimeSpan(0, 0, 0, 0, 250));
                case 1:
                    return new TimeSpan(0, 0, 0, 0, (StandardTargetSecond * 1000) + Calibration);
                case 2:
                    return base.GetStage(1).Subtract(new TimeSpan(0, 0, 0, 0, SecondaryCalibration)).Subtract(this.GetStage(1));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
    }
}
