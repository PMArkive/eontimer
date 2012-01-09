using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EonTimer
{
    class GBAAltTimer : RNGTimer
    {
        Int32 tFrame;
        DateTime init;
        Double fps;

        //Constructor 3rd Gen Alt
        public GBAAltTimer(TimerSettings settings, Boolean isGBA)
        {
            this.TimerSettings = settings;
            init = DateTime.Now;
            tFrame = 0;

            if (isGBA)
                fps = 59.7271;
            else
                fps = 59.8261;
        }

        //Overriden Methods
        public override Int32 GetLength(Int32 index)
        {
            Int32 milliseconds = -1;

            switch (index)
            {
                case 0:
                    milliseconds = (Int32)(tFrame * (1000 / fps));
                    break;
            }

            return milliseconds;
        }
        public override Int32 UpdateCalibration(int frameHit)
        {
            tFrame = frameHit;

            if (timerThread == null || !timerThread.IsAlive)
            {
                timerThread = new Thread(new ThreadStart(RunTimer));
                timerThread.Start();
            }

            return 0;
        }
        public override void Run()
        {
            init = DateTime.Now;
        }
        protected override void TimerLoop(Int32 stage)
        {
            DateTime endTime = init.AddMilliseconds(GetLength(stage));
            TimeSpan remaining = (endTime - DateTime.Now);
            Int32 actionNumber = settings.ActionCount;
            Int32 actTime = (actionNumber * settings.Frequency);

            //loop until done
            while (remaining.TotalMilliseconds > 0)
            {
                //Update the display
                UpdateDisplay(remaining);

                //perform action if neccessary
                if (remaining.TotalMilliseconds < actTime)
                {
                    actionNumber--;
                    actTime = (actionNumber * settings.Frequency);
                    settings.Action.Action();
                }

                //Sleep to reduce CPU usage
                Thread.Sleep(8);

                //update the remaining millis
                remaining = (endTime - DateTime.Now);
            }

            //perform final action
            settings.Action.Action();

            //set display to 0:00
            GUIUpdater.SetControlPropertyThreadSafe(control, "Text", "0:00");
        }
    }
}