using System;
using System.Collections.Generic;
using System.Text;

namespace ToastTimer
{
    class EntralinkTimer : DelayTimer
    {
        Int32 sCal;

        //Constructor Entralink
        public EntralinkTimer(Int32 entralinkCalibration, Int32 calibration, Int32 targetDelay, Int32 targetSecond, TimerSettings settings) : base(calibration, targetDelay, targetSecond, settings)
        {
            this.sCal = entralinkCalibration;
        }

        //overriden methods
        public override Int32 GetLength(int index)
        {
            Int32 milliseconds = -1;
            
            switch (index)
            {
                case 0:
                    milliseconds = base.GetLength(0) + 250;
                    break;
                case 1:
                    milliseconds = base.GetLength(1) - (Int32)(sCal * 1000 / 59.8261);
                    break;
            }

            return milliseconds;
        }
    }
}
