using System;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;
using System.Collections.Generic;

namespace EonTimer.Timers
{
    public class DelayTimer : SimpleTimer
    {
        public Int32 TargetDelay { get; set; }

        public DelayTimer(Int32 calibration, Int32 targetDelay, Int32 targetSecond, ConsoleType consoleType, Int32 minLength) : base(calibration, targetSecond, consoleType, minLength)
        {
            

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        public Int32 Calibrate(Int32 result)
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
                    return new TimeSpan(0, 0, 0, 0, (Int32)base.GetStage(0).TotalMilliseconds - CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType));
                case 1:
                    return new TimeSpan(0, 0, 0, 0, (CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType) + Calibration));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
    }
}
