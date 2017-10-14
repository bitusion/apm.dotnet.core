﻿using BenchmarkDotNet.Attributes;
using Bitusion.Apm.Time;
using System;
using System.Threading.Tasks;

namespace Bitusion.Apm.Benchmarks.Time
{
    [MemoryDiagnoser]
    public class UniqueUtcTimestampBenchmarkParallel
    {
        [Benchmark(Baseline = true, Description = "Plain DateTime.UtcNow")]
        public DateTime GetDateTimeUtcNow()
        {
            DateTime t = DateTime.Now;

            Parallel.For(1, 1000, (i) => t = DateTime.UtcNow);

            return t;
        }

        [Benchmark(Description = "Get DateTime")]
        public DateTime GetDateTime()
        {
            DateTime t = DateTime.Now;

            Parallel.For(1, 1000, (i) => t = UniqueUtcTimestamp.GetDateTime());

            return t;
        }

        [Benchmark(Description = "Get DateTimeOffset")]
        public DateTimeOffset GetDateTimeOffset()
        {
            DateTimeOffset t = DateTimeOffset.Now;

            Parallel.For(1, 1000, (i) => t = UniqueUtcTimestamp.GetDateTimeOffset());

            return t;
        }

        [Benchmark(Description = "Get UnixTime with nanoseconds")]
        public long GetUnixTimeWithNanoseconds()
        {
            long t = 0L;
            Parallel.For(1, 1000, (i) => t = UniqueUtcTimestamp.GetUnixTimeWithNanoseconds());
            return t;
        }
    }
}
