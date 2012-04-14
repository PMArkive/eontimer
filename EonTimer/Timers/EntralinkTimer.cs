using System;
using System.Collections.Generic;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    public class EntralinkTimer : DelayTimer
    {
        public Int32 SecondaryCalibration { get; set; }

        public EntralinkTimer(Int32 calibration, Int32 secondaryCalibration, Int32 targetDelay, Int32 targetSecond, Consoles.ConsoleType consoleType, Int32 minLength)
            : base(calibration, targetDelay, targetSecond, consoleType, minLength)
        {
            SecondaryCalibration = secondaryCalibration;

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        //overriden methods
        public override Int32 Calibrate(Int32 result)
        {
            //convert to millis
            result = CalibrationHelper.ConvertToMillis(result, ConsoleType);
            Int32 target = CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType);

            Int32 offset = result - target;

            if (Math.Abs(offset) <= TimerConstants.CLOSE_THRESHOLD)
                offset = (Int32)(TimerConstants.CLOSE_UPDATE_FACTOR * offset);
            else
                offset *= (Int32)TimerConstants.UPDATE_FACTOR;

            return SecondaryCalibration + offset;
        }

        protected override TimeSpan GetStage(Int32 stage)
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
