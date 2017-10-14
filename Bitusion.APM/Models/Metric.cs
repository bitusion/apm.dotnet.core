using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bitusion.Apm.Models
{
    public class Metric
    {
        public string Database { get; }
        public string Measurement { get; }
        public DateTime Timestamp { get; }
        public Dictionary<string, string> Fields { get; }
        public Dictionary<string, string> Tags { get; }

        public Metric(string database, string measurement, DateTime timestamp)
        {
            Database = database;
            Measurement = measurement;
            Timestamp = timestamp;
            Fields = new Dictionary<string, string>();
            Tags = new Dictionary<string, string>();
        }

        public void AddTag(string key, string value)
        {
            Tags.Add(key, value);
        }

        public void AddField(string key, int value)
        {
            Fields.Add(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void AddField(string key, bool value)
        {
            Fields.Add(key, value ? "true" : "false");
        }

        public void AddField(string key, decimal value)
        {
            Fields.Add(key, value.ToString(CultureInfo.InvariantCulture));
        }

        public void AddField(string key, string value)
        {
            Fields.Add(key, value);
        }
    }
}