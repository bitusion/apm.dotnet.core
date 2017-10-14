using BenchmarkDotNet.Attributes;
using Bitusion.Apm.Time;
using System;

namespace Bitusion.Apm.Benchmarks.Time
{
    [MemoryDiagnoser]
    public class UniqueUtcTimestampBenchmark
    {
        [Benchmark(Baseline = true, Description = "Plain DateTime.UtcNow")]
        public DateTime GetDateTimeUtcNow()
        {
            return DateTime.UtcNow;
        }

        [Benchmark(Description = "Get DateTime")]
        public DateTime GetDateTime()
        {
            return UniqueUtcTimestamp.GetDateTime();
        }

        [Benchmark(Description = "Get DateTimeOffset")]
        public DateTimeOffset GetDateTimeOffset()
        {
            return UniqueUtcTimestamp.GetDateTimeOffset();
        }

        [Benchmark(Description = "Get UnixTime with nanoseconds")]
        public long GetUnixTimeWithNanoseconds()
        {
            return UniqueUtcTimestamp.GetUnixTimeWithNanoseconds();
        }
    }
}
