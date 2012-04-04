using System;
using EonTimer.Utilities.Reference;

namespace EonTimer.Utilities.Helpers
{
    /* Converts between delays and millis */
    public static class CalibrationHelper
    {
        /// <summary>
        /// Converts a value in delays to milliseconds
        /// </summary>
        /// <param name="delays">Delays to be converted</param>
        /// <param name="type">The Console Type</param>
        /// <returns>Milliseconds</returns>
        public static Int32 ConvertToMillis(Int32 delays, ConsoleType type)
        {
            switch (type)
            {
                case ConsoleType.GBA:
                    return (Int32)(delays * TimerConstants.GBA_FRAMERATE);
                case ConsoleType.NDS:
                    return (Int32)(delays * TimerConstants.NDS_FRAMERATE);
                default:
                    return 0;
            }
        }
        /// <summary>
        /// Converts milliseconds to delays
        /// </summary>
        /// <param name="millis">Milliseconds to be converted</param>
        /// <param name="type">The console type</param>
        /// <returns>Delays</returns>
        public static Int32 ConvertToDelays(Int32 millis, ConsoleType type)
        {
            switch (type)
            {
                case ConsoleType.GBA:
                    return (Int32)(millis / TimerConstants.GBA_FRAMERATE);
                case ConsoleType.NDS:
                    return (Int32)(millis / TimerConstants.NDS_FRAMERATE);
                default:
                    return 0;
            }
        }
    }
}
