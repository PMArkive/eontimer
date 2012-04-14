using System;
using System.Collections.Generic;
using System.Text;

namespace EonTimer.Utilities
{
    public interface ITimeoutHandler
    {
        void NotifyTimeout();
    }
}
