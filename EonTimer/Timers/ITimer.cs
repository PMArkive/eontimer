using System;
using System.Collections.Generic;

namespace EonTimer.Timers
{
    public interface ITimer
    {
        List<TimeSpan> Stages { get; }

        /// <summary>
        /// Gets the offset to calibrate
        /// </summary>
        /// <param name="result">The actual result</param>
        /// <returns>The offset</returns>
        Int32 Calibrate(Int32 result);
        Int32 GetMinutesBeforeTarget();
    }
}
