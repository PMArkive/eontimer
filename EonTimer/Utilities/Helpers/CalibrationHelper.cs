using System;
using EonTimer.Utilities.Reference;

namespace EonTimer.Utilities.Helpers
{
    public static class CalibrationHelper
    {
        /// <summary>
        /// Converts a value in delays to milliseconds
        /// </summary>
        /// <param name="delays">Delays to be converted</param>
        /// <param name="type">The Console Type</param>
        /// <returns>Milliseconds</returns>
        public static Int32 ConvertToMillis(Int32 delays, Consoles.ConsoleType type)
        {
            switch (type)
            {
                case Consoles.ConsoleType.GBA:
                    return (Int32)(delays * TimerConstants.FRAMERATE_GBA);
                case Consoles.ConsoleType.NDS:
                    return (Int32)(delays * TimerConstants.FRAMERATE_NDS);
                case Consoles.ConsoleType.DSI:
                    return (Int32)(delays * TimerConstants.FRAMERATE_DSI);
                case Consoles.ConsoleType._3DS:
                    return (Int32)(delays * TimerConstants.FRAMERATE_3DS);
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
        public static Int32 ConvertToDelays(Int32 millis, Consoles.ConsoleType type)
        {
            switch (type)
            {
                case Consoles.ConsoleType.GBA:
                    return (Int32)(millis / TimerConstants.FRAMERATE_GBA);
                case Consoles.ConsoleType.NDS:
                    return (Int32)(millis / TimerConstants.FRAMERATE_NDS);
                case Consoles.ConsoleType.DSI:
                    return (Int32)(millis / TimerConstants.FRAMERATE_DSI);
                case Consoles.ConsoleType._3DS:
                    return (Int32)(millis / TimerConstants.FRAMERATE_3DS);
                default:
                    return 0;
            }
        }
        public static Int32 CreateCalibration(Int32 delay, Int32 second, Consoles.ConsoleType type)
        {
            var delayCalibration = delay - ConvertToDelays(second * 1000, type);
            return ConvertToMillis(delayCalibration, type);
        }
    }
}
