using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace EonTimer
{
    class TimerSettings
    {
        CountdownAction action;
        Int32 count, freq, min;

        public TimerSettings(CountdownAction action, Int32 frequency, Int32 actionCount, Int32 minimum)
        {
            this.action = action;
            this.freq = frequency;
            this.count = actionCount;
            this.min = minimum;
        }

        public CountdownAction Action
        {
            get { return action; }
            set { action = value; }
        }
        public Int32 Frequency
        {
            get { return freq; }
            set { freq = value; }
        }
        public Int32 ActionCount
        {
            get { return count; }
            set { count = value; }
        }
        public Int32 Minimum
        {
            get { return min; }
            set { min = value; }
        }
    }
}
