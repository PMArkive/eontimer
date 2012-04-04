using System.Collections.Generic;
using EonTimer.Handlers;
using EonTimer.Timers;

namespace EonTimer.Utilities
{
    public interface ITimerMonitor
    {
        public List<ITimerEventHandler> Handlers { get; set; }
        public ITimer Timer { get; set; }
        public void Run();
    }
}
