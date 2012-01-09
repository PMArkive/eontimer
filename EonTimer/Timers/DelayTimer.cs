using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ToastTimer
{
    class DelayTimer : RNGTimer
    {
        private Int32 calibration, tDelay, tSec;

        //Constructors (4th Gen, C-Gear)
        public DelayTimer(Int32 calibratedDelay, Int32 calibratedSecond, Int32 targetDelay, Int32 targetSecond, TimerSettings settings)
        {
            this.calibration = (Int32)(59.8261 * calibratedSecond) - calibratedDelay;
            this.tDelay = targetDelay;
            this.tSec = targetSecond;
            this.TimerSettings = settings;
            FixTarget();
        }
        public DelayTimer(Int32 calibration, Int32 targetDelay, Int32 targetSecond, TimerSettings settings)
        {
            this.calibration = -calibration;
            this.tDelay = targetDelay;
            this.tSec = targetSecond;
            this.TimerSettings = settings;
            FixTarget();
        }
        
        //DelayTimer-specific function
        private void FixTarget()
        {
            while (GetLength(0) < this.TimerSettings.Minimum * 1000)
                tSec += 60;
        }
        public Int32 SuggestSecond()
        {
            return TimerSettings.Minimum + ((GetLength(1) + 1000) / 1000);
        }


        //Override Methods
        public override Int32 GetLength(Int32 index)
        {
            Int32 milliseconds = -1;

            switch (index)
            {
                case 0:
                    milliseconds = (Int32)((tSec * 1000) - ((tDelay + calibration) * (1000 / 59.8261)));
                    break;
                case 1:
                    milliseconds = (Int32)((tDelay + calibration) * (1000 / 59.8261));
                    break;
            }

            return milliseconds;
        }
        public override Int32 UpdateCalibration(Int32 hit)
        {
            Int32 offset = hit - tDelay;

            if (Math.Abs(offset) <= 10)
                offset = (Int32)(.75 * offset);

            return offset;
        }

        //Properties
        public Int32 Calibration
        {
            get { return calibration; }
            set { calibration = value; }
        }
        public Int32 TargetDelay
        {
            get { return tDelay; }
            set { tDelay = value; }
        }
        public Int32 TargetSecond
        {
            get { return tSec; }
            set { tSec = value; }
        }
    }
}
