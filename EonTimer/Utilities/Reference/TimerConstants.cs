using System;

namespace EonTimer.Utilities.Reference
{
    public static class TimerConstants
    {
        public static readonly Decimal GBA_FPS = 59.7271M;
        public static readonly Decimal NDS_FPS = 59.8261M;
        public static readonly Decimal GBA_FRAMERATE = 1000 / GBA_FPS;
        public static readonly Decimal NDS_FRAMERATE = 1000 / NDS_FPS;

        public static readonly Decimal UPDATE_FACTOR = 1;
        public static readonly Decimal CLOSE_UPDATE_FACTOR = .75M;
        public static readonly Int32 CLOSE_THRESHOLD = 10;

        public static readonly TimeSpan NULL_TIMESPAN = new TimeSpan(-999);
    }
}
