using System;

namespace EonTimer.Timers
{
    public interface ITimer
    {
        /// <summary>
        /// Gets the length of a timer stage
        /// </summary>
        /// <param name="stage">The timer stage</param>
        /// <returns>The length as a timespan, NULL_TIMESPAN if stage does not exist.</returns>
        TimeSpan GetStage(Int32 stage);
        /// <summary>
        /// Gets the offset to calibrate
        /// </summary>
        /// <param name="result">The actual result</param>
        /// <returns>The offset</returns>
        Int32 Calibrate(Int32 result);
    }
}
