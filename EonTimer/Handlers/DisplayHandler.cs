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

        //private
        private ITimerMonitor timeMonitor;

        public DisplayHandler()
        {
            CurrentDisplays = new List<Control>();
            NextStageDisplays = new List<Control>();
            StatusDisplays = new List<Control>();
        }

        //interface
        public void Register(ITimerMonitor timer)
        {
            timeMonitor = timer;
        }
        public void NotifySetup()
        {
            foreach (Control control in CurrentDisplays)
                GUIHelper.SetControlText(control, FormatTime(timeMonitor.Timer.GetStage(1)));
            foreach (Control control in NextStageDisplays)
                GUIHelper.SetControlText(control, FormatTime(timeMonitor.Timer.GetStage(2)));
        }
        public void NotifyStageStart(Int32 stage)
        {
            TimeSpan ts = timeMonitor.Timer.GetStage(stage);

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

            String millis = ((int)ts.TotalMilliseconds / 10).ToString();
            return millis.Insert(millis.Length - 2, ":");
        }
    }
}
