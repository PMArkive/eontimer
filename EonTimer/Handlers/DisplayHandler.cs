using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EonTimer.Utilities;
using EonTimer.Utilities.Helpers;
using EonTimer.Utilities.Reference;

namespace EonTimer.Handlers
{
    public class DisplayHandler : ITimerEventHandler
    {
        //public properties
        public List<Control> CurrentDisplays { get; set; }
        public IList<Control> NextStageDisplays { get; set; }
        public IList<Control> StatusDisplays { get; set; }
        public IList<Control> MinutesBeforeDisplays { get; set; }

        //private
        private ITimerMonitor timeMonitor;

        public DisplayHandler()
        {
            CurrentDisplays = new List<Control>();
            NextStageDisplays = new List<Control>();
            StatusDisplays = new List<Control>();
            MinutesBeforeDisplays = new List<Control>();
        }

        //interface
        public void Register(ITimerMonitor timer)
        {
            timeMonitor = timer;
        }
        public void NotifySetup()
        {
            if (timeMonitor.Timer.Stages != null)
            {
                if(timeMonitor.Timer.Stages.Count > 0)
                {
                    foreach (Control control in CurrentDisplays)
                        GUIHelper.SetControlText(control, FormatTime(timeMonitor.Timer.Stages[0]));
                }

                if (timeMonitor.Timer.Stages.Count > 1)
                {
                    foreach (Control control in NextStageDisplays)
                        GUIHelper.SetControlText(control, FormatTime(timeMonitor.Timer.Stages[1]));
                }
                else
                {
                    foreach (Control control in NextStageDisplays)
                        GUIHelper.SetControlText(control, FormatTime(TimerConstants.NULL_TIMESPAN));
                }
            }

            foreach (Control control in StatusDisplays)
                GUIHelper.SetControlText(control, "Stopped");
            foreach (Control control in MinutesBeforeDisplays)
                GUIHelper.SetControlText(control, timeMonitor.Timer.GetMinutesBeforeTarget().ToString());
        }
        public void NotifyStart()
        {
            foreach (Control control in StatusDisplays)
                GUIHelper.SetControlText(control, "Running");
        }
        public void NotifyStageStart(Int32 stage)
        {
            TimeSpan ts = TimerConstants.NULL_TIMESPAN;

            if (timeMonitor.Timer.Stages.Count > stage + 1)
                ts = timeMonitor.Timer.Stages[stage + 1];

            foreach (Control control in NextStageDisplays)
                GUIHelper.SetControlText(control, FormatTime(ts));
        }
        public void NotifyUpdate(TimeSpan remaining)
        {
            foreach (Control control in CurrentDisplays)
                GUIHelper.SetControlText(control, FormatTime(remaining));
        }
        public void NotifyEnd()
        {
            NotifySetup();
        }

        //not implemented interface
        public void NotifyStageEnd(Int32 stage) { }

        private String FormatTime(TimeSpan ts)
        {
            if (ts == TimerConstants.NULL_TIMESPAN)
                return "0:00";
            else if (ts == TimerConstants.INFINITE_TIMESPAN)
                return "?:??";

            return String.Format("{0}:{1}", ((Int32)ts.TotalMilliseconds / 1000), ((Int32)ts.TotalMilliseconds / 10 % 100).ToString("D2"));
        }
        private String GetMinutesBefore()
        {
            return ((Int32)timeMonitor.Timer.Stages[0].TotalMilliseconds / 60000).ToString();
        }
    }
}
