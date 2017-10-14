``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4700MQ CPU 2.40GHz (Haswell), ProcessorCount=8
Frequency=2338348 Hz, Resolution=427.6523 ns, Timer=TSC
.NET Core SDK=2.0.2
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                          Method |     Mean |     Error |    StdDev | Scaled | ScaledSD | Allocated |
 |-------------------------------- |---------:|----------:|----------:|-------:|---------:|----------:|
 |         'Plain DateTime.UtcNow' | 16.33 ns | 0.1755 ns | 0.1641 ns |   1.00 |     0.00 |       0 B |
 |                  'Get DateTime' | 26.55 ns | 0.0457 ns | 0.0427 ns |   1.63 |     0.02 |       0 B |
 |            'Get DateTimeOffset' | 39.64 ns | 0.5296 ns | 0.4695 ns |   2.43 |     0.04 |       0 B |
 | 'Get UnixTime with nanoseconds' | 25.63 ns | 0.2565 ns | 0.2399 ns |   1.57 |     0.02 |       0 B |
