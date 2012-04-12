using System.Collections.Generic;
using EonTimer.Handlers;
using EonTimer.Timers;
using System;

namespace EonTimer.Utilities
{
    public interface ITimerMonitor
    {
        List<ITimerEventHandler> Handlers { get; }
        ITimer Timer { get; set; }

        Boolean IsRunning();
        void Run();
        void Cancel();

        void AddHandler(ITimerEventHandler handler);
        void ClearHandlers();
    }
}
