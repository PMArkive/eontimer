using System;
using System.Collections.Generic;
using System.Text;

namespace ToastTimer
{
    class CustomTimer : RNGTimer
    {
        public CustomTimer(TimerSettings settings)
        {
            this.TimerSettings = settings;
            Stages = new List<Double>();
        }

        public List<Double> Stages { get; set; }

        //Override Methods
        public override Int32 GetLength(Int32 index)
        {
            Int32 milliseconds = -1;

            if (index < Stages.Count)
                milliseconds = (Int32)Math.Round(Stages[index] * 1000);

            return milliseconds;
        }
        public override Int32 UpdateCalibration(Int32 hit)
        {
            return 0;
        }
    }
}
