using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EonTimer.Timers;
using EonTimer.Handlers;
using System.Threading;

namespace EonTimer.Utilities
{
    public class TimeMonitor : ITimerMonitor
    {
        //public properties
        public List<ITimerEventHandler> Handlers
        {
            get;
            set
            {
                foreach (ITimerEventHandler h in Handlers)
                    h.Register(this);
            }
        }
        public ITimer Timer { get; set; }

        //private
        private Thread thread;

        public TimeMonitor()
        {
            Handlers = new List<ITimerEventHandler>();
        }

        public void Run()
        {
            if (thread == null || !thread.IsAlive)
            {
                thread = new Thread(new ThreadStart(RunTimer));
                thread.Start();
            }
        }
        private void RunTimer()
        {
            foreach (ITimerEventHandler h in Handlers)
                h.NotifyStart();

            Int32 stage = 0;
            while (Timer.GetStage(stage) != TimerConstants.NULL_TIMESPAN)
            {
                RunStage(stage);
                stage++;
            }

            foreach (ITimerEventHandler h in Handlers)
                h.NotifyEnd();
        }
        private void RunStage(Int32 stage)
        {
            DateTime endTime = DateTime.Now.Add(Timer.GetStage(stage));
            Int32 sleepPeriod = 8;
            TimeSpan remaining = (endTime - DateTime.Now);

            foreach (ITimerEventHandler h in Handlers)
                h.NotifyStageStart(stage);

            while (remaining.TotalMilliseconds > 0)
            {
                Thread.Sleep(sleepPeriod);
                remaining = (endTime - DateTime.Now);

                foreach (ITimerEventHandler h in Handlers)
                    h.NotifyUpdate(remaining);
            }

            foreach (ITimerEventHandler h in Handlers)
                h.NotifyStageEnd(stage);
        }
    }

    /*public class TimerMonitor : ITimerEventHandler
    {
        //public properties
        public IList<Control> TimeDisplayControls { get; set; }
        public IList<Control> SecondaryTimeDisplayControls { get; set; }
        public IList<Control> ActionDisplayControls { get; set; }
        public IList<Control> StatusDisplayControls { get; set; }

        public IList<ICountdownAction> CountdownActions { get; set; }
        public Int32 ActionFrequency { get; set; }
        public Int32 ActionCount { get; set; }
        public Int32 MinimumLength { get; set; }

        //private members
        private Int32 nextAction;
        private RNGTimer timer;

        //constructor
        public TimerMonitor()
        {
            Reset();
        }

        //interface methods
        public void Register(RNGTimer t)
        {
            timer = t;
            UpdateDisplay(t.GetStage(0));
        }
        public void NotifyStart()
        {
            UpdateStatus("Cancel");
        }
        public void NotifyStageStart()
        {
            //Nothing for now
        }
        public void NotifyUpdate()
        {
            if (timer == null)
                return;

            UpdateDisplay(timer.Remaining);

            if(timer.Remaining.TotalMilliseconds < nextAction)
            {
                TriggerAction();
                nextAction -= ActionFrequency;
            }
        }
        public void NotifyStageEnd()
        {
            TriggerAction();
            Reset();
        }
        public void NotifyEnd()
        {
            UpdateStatus("Start");
        }

        //private methods
        private void UpdateStatus(String status)
        {
            foreach (Control c in StatusDisplayControls)
                GUIUpdater.SetControlText(c, status);
        }
        private void UpdateDisplay(TimeSpan remaining)
        {
            String current = String.Format("{0}:{1}", (remaining.TotalMilliseconds / 1000), (remaining.TotalMilliseconds % 1000));

            foreach (Control c in TimeDisplayControls)
                GUIUpdater.SetControlText(c, current);
        }
        private void TriggerAction()
        {
            foreach (ICountdownAction a in CountdownActions)
                a.Action();
        }
        private void Reset()
        {
            nextAction = (ActionCount - 1) * ActionFrequency;
        }
    }*/
}
