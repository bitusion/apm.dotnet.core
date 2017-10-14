using BenchmarkDotNet.Attributes;
using Bitusion.Apm.Models;
using Bitusion.Apm.Formatters;
using Newtonsoft.Json;
using System;

namespace Bitusion.Apm.Benchmarks.Formatters
{
    [MemoryDiagnoser]
    public class MetricFormattersBenchmark
    {
        private static readonly Metric Metric;

        static MetricFormattersBenchmark()
        {
            Metric = new Metric("db", "measurement", DateTime.UtcNow);
            Metric.AddField("int", 10);
            Metric.AddField("boolean", true);
            Metric.AddField("decimal", 1.99m);
            Metric.AddTag("tag1", "tagValue1");
            Metric.AddTag("tag2", "tagValue2");
            Metric.AddTag("tag3", "tagValue3");
            Metric.AddTag("tag4", "tagValue4");
            Metric.AddTag("tag5", "tagValue5");
        }

        [Benchmark(Baseline = true, Description = "Newtonsoft Json")]
        public string NewtonsoftJson()
        {
            return JsonConvert.SerializeObject(Metric);
        }

        [Benchmark(Description = "Metric JSON Formatter")]
        public string Json()
        {
            return new MetricJsonFormatter().Format(Metric);
        }
    }
}
