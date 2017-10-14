``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4700MQ CPU 2.40GHz (Haswell), ProcessorCount=8
Frequency=2338348 Hz, Resolution=427.6523 ns, Timer=TSC
.NET Core SDK=2.0.2
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                     Method |     Mean |    Error |   StdDev |   Median | Scaled |  Gen 0 | Allocated |
 |--------------------------- |---------:|---------:|---------:|---------:|-------:|-------:|----------:|
 | 'Metric Publisher Publish' | 241.8 ns | 18.73 ns | 54.04 ns | 212.0 ns |   1.00 | 0.0001 |       0 B |
