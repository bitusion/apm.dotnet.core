using Bitusion.Apm.Formatters;
using Bitusion.Apm.Models;
using FluentAssertions;
using System;
using Xunit;

namespace Bitusion.Apm.Tests.Unit.Formatters
{
    public class MetricJsonFormatterTests
    {
        [Fact]
        public void Format()
        {
            var metric = new Metric("db", "measurement", new DateTime(2017, 6, 2, 14, 18, 53, 999, DateTimeKind.Utc));

            metric.AddField("int", 10);
            metric.AddField("boolean", true);
            metric.AddField("decimal", 1.99m);

            metric.AddTag("tag1", "tagValue1");
            metric.AddTag("tag2", "tagValue2");
            metric.AddTag("tag3", "tagValue3");
            metric.AddTag("tag4", "tagValue4");
            metric.AddTag("tag5", "tagValue5");

            var serialized = new MetricJsonFormatter().Format(metric);

            serialized.Should().Be("{\"db\":\"db\",\"precision\":\"n\",\"measurement\":\"measurement\",\"timestamp\":\"2017-06-02T14:18:53.9990000Z\",\"fields\":{\"int\":10,\"boolean\":true,\"decimal\":1.99},\"tags\":{\"tag1\":\"tagValue1\",\"tag2\":\"tagValue2\",\"tag3\":\"tagValue3\",\"tag4\":\"tagValue4\",\"tag5\":\"tagValue5\"}}");
        }
    }
}
