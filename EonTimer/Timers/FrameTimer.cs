using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Utilities.Reference;
using EonTimer.Utilities.Helpers;

namespace EonTimer.Timers
{
    class FrameTimer : ITimer
    {
        public Int32 PretimerLength { get; set; }
        public Int32 Calibration { get; set; }
        public Int32 TargetFrame { get; set; }
        public ConsoleType ConsoleType { get; set; }

        public TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return new TimeSpan(0, 0, 0, 0, PretimerLength);
                case 1:
                    return new TimeSpan(0, 0, 0, 0, CalibrationHelper.ConvertToMillis(TargetFrame, ConsoleType) + Calibration);
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
        public Int32 Calibrate(Int32 result)
        {
            return CalibrationHelper.ConvertToMillis((TargetFrame - result), ConsoleType);
        }
    }
}
