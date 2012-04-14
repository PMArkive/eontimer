using System.Collections.Generic;
using EonTimer.Handlers;
using EonTimer.Timers;
using System;

namespace EonTimer.Utilities
{
    public interface ITimerMonitor
    {
        List<ITimerEventHandler> Handlers { get; }
        List<ITimeoutHandler> TimeoutHandlers { get; }
        ITimer Timer { get; set; }

        Boolean IsRunning();
        void Run();
        void Cancel();

        void AddHandler(ITimerEventHandler handler);
        void AddHandler(ITimeoutHandler handler);
        void ClearHandlers();
    }
}
