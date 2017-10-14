using Bitusion.Apm.Models;

namespace Bitusion.Apm.Formatters
{
    public interface IMetricFormatter
    {
        string Format(Metric metric);
    }
}