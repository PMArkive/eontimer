using System;
using System.Threading;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;
using System.Collections.Generic;

namespace EonTimer.Timers
{
    public class VariableTargetFrameTimer : ITimer, IVariableTimer
    {
        private Int32 targetFrame;

        public Int32 TargetFrame
        {
            get { return targetFrame; }
            set
            {
                targetFrame = value;
                PrepareStages(); 
            }
        }
        public Consoles.ConsoleType ConsoleType { get; set; }
        public List<TimeSpan> Stages { get; protected set; }

        public VariableTargetFrameTimer(Consoles.ConsoleType consoleType)
        {
            ConsoleType = consoleType;
            TargetFrame = -1;
            PrepareStages();
        }
        
        public Int32 Calibrate(Int32 hit)
        {
            return 0;
        }
        public Int32 GetMinutesBeforeTarget()
        {
            return 0;
        }
        public void Reset()
        {
            TargetFrame = -1;
            PrepareStages();
        }

        private void PrepareStages()
        {
            Stages = new List<TimeSpan>();
            for (Int32 i = 0; GetStage(i) != TimerConstants.NULL_TIMESPAN; i++)
                Stages.Add(GetStage(i));
        }
        private TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                    return CalculateTarget();
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }
        private TimeSpan CalculateTarget()
        {
            if (targetFrame == -1)
                return TimerConstants.INFINITE_TIMESPAN;
            else
                return new TimeSpan(0, 0, 0, 0, CalibrationHelper.ConvertToMillis(targetFrame, ConsoleType));
        }
    }
}