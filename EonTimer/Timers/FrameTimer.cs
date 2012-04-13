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
        public Consoles.ConsoleType ConsoleType { get; set; }
        public List<TimeSpan> Stages { get; private set; }

        public FrameTimer(Int32 calibration, Int32 pretimer, Int32 targetFrame, Consoles.ConsoleType consoleType)
        {
            Calibration = calibration;
            PretimerLength = pretimer;
            TargetFrame = targetFrame;
            ConsoleType = consoleType;

            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }

        public Int32 Calibrate(Int32 result)
        {
            return CalibrationHelper.ConvertToMillis((TargetFrame - result), ConsoleType);
        }
        public Int32 GetMinutesBeforeTarget()
        {
            return 0;
        }

        private TimeSpan GetStage(Int32 stage)
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
    }
}
