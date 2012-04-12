using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using EonTimer.Timers;
using EonTimer.Handlers;
using System.Threading;
using EonTimer.Utilities.Reference;

namespace EonTimer.Utilities
{
    public class TimeMonitor : ITimerMonitor
    {
        //public properties
        public List<ITimerEventHandler> Handlers { get { return handlers; } }
        public ITimer Timer
        {
            get { return timer; }
            set
            {
                timer = value;
                foreach (var handler in Handlers)
                    handler.NotifySetup();
            }
        }
        public Int32 SleepInterval { get; set; }

        //private
        private Thread thread;
        private ITimer timer;
        private List<ITimerEventHandler> handlers;

        public TimeMonitor(ITimer timer, Int32 sleepInterval = 8)
        {
            handlers = new List<ITimerEventHandler>();
            Timer = timer;
            SleepInterval = sleepInterval;
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

            for(Int32 stage = 0; stage < Timer.Stages.Count; stage++)
                RunStage(stage);

            foreach (ITimerEventHandler h in Handlers)
                h.NotifyEnd();
        }
        private void RunStage(Int32 stage)
        {
            DateTime start = DateTime.Now;

            PauseWhileNull(stage);

            //stage length is committed at this point
            DateTime endTime = start.Add(Timer.Stages[stage]);
            TimeSpan remaining = (endTime - DateTime.Now);


            foreach (ITimerEventHandler h in Handlers)
                h.NotifyStageStart(stage);

            //main timer loop
            while (remaining.TotalMilliseconds > 0)
            {
                Thread.Sleep(SleepInterval);
                remaining = (endTime - DateTime.Now);

                foreach (ITimerEventHandler h in Handlers)
                    h.NotifyUpdate(remaining);
            }


            foreach (ITimerEventHandler h in Handlers)
                h.NotifyStageEnd(stage);
        }

        public void Cancel()
        {
            foreach(var handler in Handlers)
                handler.NotifyEnd();

            if(IsRunning())
                thread.Abort();
        }
        public Boolean IsRunning()
        {
            return (thread != null && thread.IsAlive);
        }

        public void AddHandler(ITimerEventHandler handler)
        {
            handler.Register(this);
            handlers.Add(handler);
        }
        public void ClearHandlers()
        {
            handlers.Clear();
        }

        //Acts as a pause for variable-target timers
        private void PauseWhileNull(Int32 stage)
        {
            while (Timer.Stages[stage] == TimerConstants.NULL_TIMESPAN)
                Thread.Sleep(SleepInterval);
        }
    }
}
