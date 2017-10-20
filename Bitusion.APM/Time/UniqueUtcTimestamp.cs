using System;
using System.Threading;

namespace Bitusion.Apm.Time
{
    public static class UniqueUtcTimestamp
    {
        private static long _lastTimeStamp = DateTime.UtcNow.Ticks;
        private const long EpochTicks = 621355968000000000L;

        public static DateTime GetDateTime()
        {
            return new DateTime(GetUniqueTick(), DateTimeKind.Utc);
        }

        public static DateTimeOffset GetDateTimeOffset()
        {
            return new DateTimeOffset(GetUniqueTick(), TimeSpan.Zero);
        }

        public static long GetUnixTimeWithNanoseconds()
        {
            return (GetUniqueTick() - EpochTicks) * 100L;
        }

        private static long GetUniqueTick()
        {
            long original, newValue;
            do
            {
                original = _lastTimeStamp;
                var now = DateTime.UtcNow.Ticks;
                newValue = Math.Max(now, original + 1);
            }
            while (Interlocked.CompareExchange(ref _lastTimeStamp, newValue, original) != original);

            return newValue;
        }
    }
}
