using Bitusion.Apm.Models;
using System.Text;

namespace Bitusion.Apm.Formatters
{
    /// <summary>
    /// Json formatter of the metric
    /// </summary>
    public class MetricJsonFormatter : IMetricFormatter
    {
        public string Format(Metric metric)
        {
            var builder = new StringBuilder(256);
            builder.Append('{');
            JoinKeyValue(builder, "db", metric.Database);
            builder.Append(',');
            JoinKeyValue(builder, "precision", "n");
            builder.Append(',');
            JoinKeyValue(builder, "measurement", metric.Measurement);
            builder.Append(',');
            JoinKeyValue(builder, "timestamp", metric.Timestamp.ToString("o"));
            builder.Append(',');
            JoinKeyValue(builder, "fields", "{", false);
            var count = metric.Fields.Count;
            foreach (var field in metric.Fields)
            {
                JoinKeyValue(builder, field.Key, field.Value, false);
                count--;
                if (count > 0)
                    builder.Append(',');
            }
            builder.Append('}');
            builder.Append(',');
            JoinKeyValue(builder, "tags", "{", false);
            count = metric.Tags.Count;
            foreach (var tag in metric.Tags)
            {
                JoinKeyValue(builder, tag.Key, tag.Value);
                count--;
                if (count > 0)
                    builder.Append(',');
            }
            builder.Append('}');
            builder.Append('}');

            return builder.ToString();
        }

        private static void JoinKeyValue(StringBuilder builder, string key, string value, bool encloseValueInDoubleQuotes = true)
        {
            EncloseInDoubleQuotes(builder, key);
            builder.Append(':');
            if (encloseValueInDoubleQuotes)
                EncloseInDoubleQuotes(builder, value);
            else
                builder.Append(value);
        }

        private static void EncloseInDoubleQuotes(StringBuilder builder, string value)
        {
            builder.Append("\"");
            builder.Append(value);
            builder.Append("\"");
        }
    }
}
