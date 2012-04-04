using EonTimer.Timers;
using System;
using EonTimer.Utilities;

namespace EonTimer.Handlers
{
    public interface ITimerEventHandler
    {
        void Register(ITimerMonitor timer);
        void NotifySetup();

        void NotifyStart();
        void NotifyStageStart(Int32 stage);
        void NotifyUpdate(TimeSpan remaining);
        void NotifyStageEnd(Int32 stage);
        void NotifyEnd();
    }
}
