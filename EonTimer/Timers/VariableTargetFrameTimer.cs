using System;
using System.Threading;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;

namespace EonTimer.Timers
{
    class VariableTargetFrameTimer : ITimer
    {
        public Int32 TargetFrame { get; set; }
        public ConsoleType ConsoleType { get; set; }

        public TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
        public override Int32 UpdateCalibration(int frameHit)
        {
            return 0;
        }
    }
}