using System;
using System.Collections.Generic;
using System.Text;

namespace ToastTimer
{
    class StandardSeedTimer : RNGTimer
    {
        private Int32 calibration, tSec;

        //Constructor 5th Gen Standard Seeds
        public StandardSeedTimer(Int32 calibration, Int32 targetSecond, TimerSettings settings)
        {
            this.calibration = calibration;
            this.tSec = targetSecond;
            this.TimerSettings = settings;
            FixTarget();
        }
        private void FixTarget()
        {
            while (GetLength(0) < this.TimerSettings.Minimum * 1000)
                tSec += 60;
        }

        //Overriden Methods
        public override Int32 GetLength(int index)
        {
            Int32 milliseconds = -1;

            if (index == 0)
                milliseconds = (tSec * 1000) + (Int32)(calibration * (1000 / 59.8261));

            return milliseconds;
        }
        public override Int32 UpdateCalibration(int hit)
        {
            if (hit == tSec)
                return 0;
            else if (hit > tSec)
                return ((tSec - hit + 1) * 60 - 30);
            else
                return ((tSec - hit - 1) * 60 + 30);
        }
    }
}
