``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4700MQ CPU 2.40GHz (Haswell), ProcessorCount=8
Frequency=2338348 Hz, Resolution=427.6523 ns, Timer=TSC
.NET Core SDK=2.0.2
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                  Method |       Mean |    Error |   StdDev | Scaled |  Gen 0 | Allocated |
 |------------------------ |-----------:|---------:|---------:|-------:|-------:|----------:|
 |       'Newtonsoft Json' | 3,425.5 ns | 44.02 ns | 41.18 ns |   1.00 | 0.6714 |   2.07 KB |
 | 'Metric JSON Formatter' |   964.6 ns | 11.45 ns | 10.15 ns |   0.28 | 0.3910 |    1.2 KB |
