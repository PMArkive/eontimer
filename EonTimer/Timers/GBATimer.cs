using System;
using System.Collections.Generic;
using System.Text;

namespace ToastTimer
{
    class GBATimer : RNGTimer
    {
        Int32 preTime, calibration, tFrame;
        Double fps;

        //Constructor 3rd Gen
        public GBATimer(Int32 preTime, Int32 calibration, Int32 targetFrame, TimerSettings settings, Boolean isGBA)
        {
            this.preTime = preTime;
            this.calibration = calibration;
            this.tFrame = targetFrame;
            this.TimerSettings = settings;

            if (isGBA)
                fps = 59.7271;
            else
                fps = 59.8261;
        }

        //Overriden Methods
        public override int GetLength(int index)
        {
            Int32 milliseconds = -1;

            switch (index)
            {
                case 0:
                    milliseconds = preTime * 1000;
                    break;
                case 1:
                    milliseconds = (Int32)(tFrame * (1000 / fps)) + calibration;
                    break;
            }

            return milliseconds;
        }
        public override int UpdateCalibration(int frameHit)
        {
            return (Int32)((tFrame - frameHit) * (1000 / 59.8261));
        }
    }
}
