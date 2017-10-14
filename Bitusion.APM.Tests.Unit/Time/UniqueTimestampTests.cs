using Bitusion.Apm.Time;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Bitusion.Apm.Tests.Unit.Time
{
    public class UniqueTimestampTests
    {
        [Fact]
        public void AreUniqueDateTimes()
        {
            var t1 = UniqueUtcTimestamp.GetDateTime();
            var t2 = UniqueUtcTimestamp.GetDateTime();

            t2.Subtract(t1).Ticks.Should().BeGreaterThan(0);
        }

        [Fact]
        public void AreUniqueDateTimeOffsets()
        {
            var t1 = UniqueUtcTimestamp.GetDateTimeOffset();
            var t2 = UniqueUtcTimestamp.GetDateTimeOffset();

            t2.Subtract(t1).Ticks.Should().BeGreaterThan(0);
        }

        [Fact]
        public void AreUniqueUnixTimestamps()
        {
            var t1 = UniqueUtcTimestamp.GetUnixTimeWithNanoseconds();
            var t2 = UniqueUtcTimestamp.GetUnixTimeWithNanoseconds();

            t2.CompareTo(t1).Should().BeGreaterThan(0);
        }

        [Fact]
        public void AreUniqueDateTimesParallel()
        {
            var list = new System.Collections.Concurrent.ConcurrentDictionary<long, DateTime>();

            const int valueCount = 1000;

            Parallel.For(0, valueCount, i =>
            {
                var t = UniqueUtcTimestamp.GetDateTime();
                list.TryAdd(t.Ticks, t);
            });

            list.Count.Should().Be(valueCount);
        }

        [Fact]
        public void AreUniqueDateTimeOffsetsParallel()
        {
            var list = new System.Collections.Concurrent.ConcurrentDictionary<long, DateTimeOffset>();

            const int valueCount = 1000;

            Parallel.For(0, valueCount, i =>
            {
                var t = UniqueUtcTimestamp.GetDateTimeOffset();
                list.TryAdd(t.Ticks, t);
            });

            list.Count.Should().Be(valueCount);
        }
    }
}
