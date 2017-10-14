using System;
using System.Collections.Generic;

namespace Bitusion.Apm.Models
{
    public class Batch
    {
        private DateTime _deadline;
        private readonly TimeSpan _nextDeadlineStep;

        public int Count { get { return Items.Count; } }
        public List<Metric> Items { get; }

        public Batch(int batchSize, TimeSpan nextDeadlineStep)
        {
            _nextDeadlineStep = nextDeadlineStep;
            Items = new List<Metric>(batchSize);
            SetNextDeadLine();
        }

        public void Add(Metric metric)
        {
            Items.Add(metric);
        }

        public void Reset()
        {
            Items.Clear();
            SetNextDeadLine();
        }

        public bool OverDeadline()
        {
            return DateTime.UtcNow >= _deadline;
        }

        private void SetNextDeadLine()
        {
            _deadline = DateTime.UtcNow.Add(_nextDeadlineStep);
        }
    }
}
