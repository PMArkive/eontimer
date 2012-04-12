using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    public class SimpleTimer : ITimer
    {
        public Int32 Calibration { get; set; }
        public Int32 TargetSecond { get; set; }
        public ConsoleType ConsoleType { get; set; }
        public List<TimeSpan> Stages { get; protected set; }
        public Int32 MinimumLength { get; set; }

        public SimpleTimer(Int32 calibration, Int32 targetSecond, ConsoleType consoleType, Int32 minLength)
        {
            Calibration = calibration;
            TargetSecond = targetSecond;
            ConsoleType = consoleType;
            MinimumLength = minLength;

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        public Int32 Calibrate(Int32 result)
        {
            if (result == TargetSecond)
                return 0;
            else if (result > TargetSecond)
                return ((TargetSecond - result) * 1000 + 500);
            else
                return ((TargetSecond - result) * 1000 - 500);
        }
        public Int32 GetMinutesBeforeTarget()
        {
            var ts = new TimeSpan(0);

            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                ts = ts.Add(GetStage(i));

            return (Int32)ts.TotalMilliseconds / 60000;
        }

        protected virtual TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    var first = TargetSecond * 1000 + Calibration + 200;
                    while (first < MinimumLength)
                        first += 60000;
                    return new TimeSpan(0, 0, 0, 0, first);

                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
    }
}
