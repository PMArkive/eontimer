using System;

namespace EonTimer.Utilities.Reference
{
    public static class TimerConstants
    {
        public static readonly Decimal FPS_GBA = 59.7271M;
        public static readonly Decimal FPS_NDS = 59.8261M;
        public static readonly Decimal FPS_DSI = 59.8261M;
        public static readonly Decimal FPS_3DS = 59.8261M;
        public static readonly Decimal FRAMERATE_GBA = 1000 / FPS_GBA;
        public static readonly Decimal FRAMERATE_NDS = 1000 / FPS_NDS;
        public static readonly Decimal FRAMERATE_DSI = 1000 / FPS_DSI;
        public static readonly Decimal FRAMERATE_3DS = 1000 / FPS_3DS;

        public static readonly Decimal UPDATE_FACTOR = 1;
        public static readonly Decimal CLOSE_UPDATE_FACTOR = .75M;
        public static readonly Int32 CLOSE_THRESHOLD = 167;

        public static readonly TimeSpan NULL_TIMESPAN = new TimeSpan(-999);
        public static readonly TimeSpan INFINITE_TIMESPAN = new TimeSpan(-99);
    }
}
