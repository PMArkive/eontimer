using System;
using System.Collections.Generic;
using EonTimer.Utilities.Reference;
using EonTimer.Utilities.Helpers;

namespace EonTimer.Timers
{
    public class EnhancedEntralinkTimer : EntralinkTimer
    {
        public Int32 TargetFrame { get; set; }
        public Int32 NPCCount { get; set; }
        public Int32 InitialAdvances { get; set; }
        public Int32 FrameCalibration { get; set; }

        public EnhancedEntralinkTimer(Int32 calibration, Int32 secondaryCalibration, Int32 targetDelay, Int32 targetSecond, Int32 targetFrame, Int32 frameCalibration, Consoles.ConsoleType consoleType, Int32 minLength, Boolean initialize = true)
            : base(calibration, secondaryCalibration, targetDelay, targetSecond, consoleType, minLength, false)
        {
            TargetFrame = targetFrame;
            NPCCount = 0;
            InitialAdvances = 0;
            FrameCalibration = frameCalibration;

            if (initialize)
                Initialize();
        }

        public new virtual Int32 Calibrate(Int32 result)
        {
            Decimal npcRate = 1.0M / CalibrationHelper.ConvertToMillis(32, ConsoleType);
            return (Int32)Math.Round((TargetFrame - result) / (TimerConstants.ENTRALINK_FRAMERATE + (NPCCount * npcRate))) * 1000;
        }

        protected override TimeSpan GetStage(Int32 stage)
        {
            switch (stage)
            {
                case 0:
                case 1:
                    return base.GetStage(stage);
                case 2:
                    return CalcFrameTime();
                default:
                    return TimerConstants.NULL_TIMESPAN;
            }
        }

        public override Int32 GetMinutesBeforeTarget()
        {
            var ts = new TimeSpan(0);

            for (Int32 i = 0; i < 2; i++)
                ts = ts.Add(Stages[i]);

            return (Int32)ts.TotalMilliseconds / 60000;
        }

        private TimeSpan CalcFrameTime()
        {
            Int32 frames = TargetFrame - InitialAdvances;
            Decimal npcRate = 1.0M / CalibrationHelper.ConvertToMillis(32, ConsoleType);
            Int32 ms = (Int32)Math.Round((frames) / (TimerConstants.ENTRALINK_FRAMERATE + (NPCCount * npcRate))) * 1000 + FrameCalibration;
            return new TimeSpan(0,0,0,0, ms);
        }
    }
}
