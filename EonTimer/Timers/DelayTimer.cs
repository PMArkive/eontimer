using System;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    public class DelayTimer : ITimer
    {
        public Int32 TargetDelay { get; set; }
        public Int32 TargetSecond { get; set; }
        /// <summary>Calibration in milliseconds</summary>
        public Int32 Calibration { get; set; }

        //interface methods
        public TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return new TimeSpan((Int64)((TargetSecond * 1000) - (CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType.NDS) + Calibration * TimerConstants.NDS_FRAMERATE) + 200));
                case 1:
                    return new TimeSpan((Int64)(CalibrationHelper.ConvertToMillis(TargetDelay, ConsoleType.NDS) + Calibration));
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
        /// <returns>Offset in delays</returns>
        public Int32 Calibrate(Int32 result)
        {
            Int32 offset = result - TargetDelay;

            if (Math.Abs(offset) <= TimerConstants.CLOSE_THRESHOLD)
                offset = (Int32)(TimerConstants.CLOSE_UPDATE_FACTOR * offset);
            else
                offset *= (Int32)TimerConstants.UPDATE_FACTOR;

            return offset;
        }
    }
}
