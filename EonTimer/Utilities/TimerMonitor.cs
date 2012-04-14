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
        public List<ITimeoutHandler> TimeoutHandlers { get { return timeoutHandlers; } }
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
        private List<ITimeoutHandler> timeoutHandlers;

        public TimeMonitor(ITimer timer, Int32 sleepInterval = 8)
        {
            handlers = new List<ITimerEventHandler>();
            timeoutHandlers = new List<ITimeoutHandler>();
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


            if (Timer is IVariableTimer)
                (Timer as IVariableTimer).Reset();
            foreach (ITimerEventHandler h in Handlers)
                h.NotifyEnd();

            foreach (var handler in TimeoutHandlers)
                handler.NotifyTimeout();
        }
        private void RunStage(Int32 stage)
        {
            DateTime start = DateTime.Now;

            PauseWhileInfinite(stage);

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
            if(IsRunning())
                thread.Abort();

            //wait to update display until thread stops
            while (IsRunning()) { }

            foreach (var handler in Handlers)
                handler.NotifyEnd();
            foreach (var handler in TimeoutHandlers)
                handler.NotifyTimeout();
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
        public void AddHandler(ITimeoutHandler handler)
        {
            timeoutHandlers.Add(handler);
        }
        public void ClearHandlers()
        {
            handlers.Clear();
            timeoutHandlers.Clear();
        }

        //Acts as a pause for variable-target timers
        private void PauseWhileInfinite(Int32 stage)
        {
            while (Timer.Stages[stage] == TimerConstants.INFINITE_TIMESPAN)
                Thread.Sleep(SleepInterval);
        }
    }
}
