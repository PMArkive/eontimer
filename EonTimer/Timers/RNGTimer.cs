using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EonTimer
{
    abstract class RNGTimer
    {
        protected Control control;
        protected Control startStopControl;
        protected TimerSettings settings;
        protected Thread timerThread;

        //Properties
        public Control DisplayControl
        {
            get { return control; }
            set { control = value; }
        }
        public Control StartStopControl
        {
            get { return startStopControl; }
            set { startStopControl = value; }
        }
        public TimerSettings TimerSettings
        {
            get { return settings; }
            set { settings = value; }
        }

        //Abstract Methods
        public abstract Int32 GetLength(Int32 index);
        public abstract Int32 UpdateCalibration(Int32 hit);

        //Run Timer
        public virtual void Run()
        {
            if (timerThread == null || !timerThread.IsAlive)
            {
                timerThread = new Thread(new ThreadStart(RunTimer));
                timerThread.Priority = ThreadPriority.AboveNormal;
                timerThread.Start();
            }
        }
        protected virtual void RunTimer()
        {

            UpdateStartStop("Cancel");

            int i = 0;

            while (GetLength(i) != -1)
            {
                TimerLoop(i);
                i++;
            }

            UpdateStartStop("Start");
        }
        protected virtual void TimerLoop(Int32 stage)
        {
            DateTime endTime = DateTime.Now.AddMilliseconds(GetLength(stage));
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
        protected void UpdateStartStop(String status)
        {
            try
            {
                startStopControl.Text = status;
            }
            catch (Exception)
            {
                //do nothing
            }
        }

        //Interrupt Timer
        public void CancelRun()
        {
            if (timerThread == null)
                return;
            else if (timerThread.IsAlive)
                timerThread.Abort();

            UpdateStartStop("Start");
        }

        //Check status
        public Boolean IsRunning()
        {
            if (timerThread == null || !timerThread.IsAlive)
                return false;
            else
                return true;
        }

        //Updates with the remaining time
        public void UpdateDisplay(TimeSpan time)
        {
            String timeString = String.Format("{0:0:00}", time.TotalMilliseconds / 10);
            GUIUpdater.SetControlPropertyThreadSafe(control, "Text", timeString);
        }
    }
}
