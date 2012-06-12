using System;
using System.Collections.Generic;
using System.Text;
using EonTimer.Timers;
using EonTimer.Utilities;
using EonTimer.Utilities.Helpers;
using System.Windows.Forms;

namespace EonTimer.Handlers
{
    public class ActionHandler : ITimerEventHandler
    {
        //public properties
        public List<ICountdownAction> Actions;
        public TimeSpan Interval { get; set; }
        public Int32 ActionCount { get; set; }

        //private
        private ITimerMonitor timeMonitor;
        private TimeSpan nextAction;

        public ActionHandler()
        {
            Actions = new List<ICountdownAction>();
        }

        //interface methods
        public void Register(ITimerMonitor timer)
        {
            timeMonitor = timer;
        }
        public void NotifyStageStart(Int32 stage)
        {
            TimeSpan next = new TimeSpan(Interval.Ticks * (ActionCount - 1));
            TimeSpan stageTime = timeMonitor.Timer.Stages[stage];


            if (stageTime < next && Interval.TotalMilliseconds != 0)
                nextAction = new TimeSpan(0, 0, 0, 0, (Int32)stageTime.TotalMilliseconds / (Int32)Interval.TotalMilliseconds * (Int32)Interval.TotalMilliseconds); //keeps intervals even
            else
                nextAction = next;
        }
        public void NotifyUpdate(TimeSpan remaining)
        {
            if (remaining < nextAction)
            {
                foreach (ICountdownAction action in Actions)
                    action.Action();

                nextAction = nextAction.Subtract(Interval);
            }
        }

        //Unused interface methods
        public void NotifySetup() { }
        public void NotifyStart() { }
        public void NotifyStageEnd(Int32 stage) { }
        public void NotifyEnd() { }
    }
}
