using System;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;
using System.Collections.Generic;

namespace EonTimer.Timers
{
    public class DelayTimer : SimpleTimer
    {
        public Int32 TargetDelay { get; set; }

        public DelayTimer(Int32 calibration, Int32 targetDelay, Int32 targetSecond, Consoles.ConsoleType consoleType, Int32 minLength, Boolean initialize = true)
            : base(calibration, targetSecond, consoleType, minLength, false)
        {
            TargetDelay = targetDelay;

            if (initialize)
                Initialize();
        }

        public new virtual Int32 Calibrate(Int32 result)
        {
            //convert to millis
            result = CalibrationHelper.ConvertToMillis(result, ConsoleType);
            Int32 target = CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType);

            Int32 offset = result - target;

            if (Math.Abs(offset) <= TimerConstants.CLOSE_THRESHOLD)
                offset = (Int32)(TimerConstants.CLOSE_UPDATE_FACTOR * offset);
            else
                offset *= (Int32)TimerConstants.UPDATE_FACTOR;

            return offset;
        }

        protected override TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    var ts = new TimeSpan(0, 0, 0, 0, (Int32)base.GetStage(0).TotalMilliseconds - CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType));
                    while ((Int32)ts.TotalMilliseconds < MinimumLength)
                        ts = ts.Add(new TimeSpan(0, 1, 0));
                    return ts;
                case 1:
                    return new TimeSpan(0, 0, 0, 0, (CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType) - Calibration));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
    }
}
