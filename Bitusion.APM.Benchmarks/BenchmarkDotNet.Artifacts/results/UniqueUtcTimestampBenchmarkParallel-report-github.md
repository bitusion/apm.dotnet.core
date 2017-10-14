``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4700MQ CPU 2.40GHz (Haswell), ProcessorCount=8
Frequency=2338348 Hz, Resolution=427.6523 ns, Timer=TSC
.NET Core SDK=2.0.2
  [Host]     : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  DefaultJob : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT


```
 |                          Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |  Gen 0 | Allocated |
 |-------------------------------- |----------:|----------:|----------:|-------:|---------:|-------:|----------:|
 |         'Plain DateTime.UtcNow' |  22.94 us | 0.1012 us | 0.0845 us |   1.00 |     0.00 | 0.9755 |    1.8 KB |
 |                  'Get DateTime' | 169.03 us | 1.2750 us | 1.1926 us |   7.37 |     0.06 | 0.9766 |    1.8 KB |
 |            'Get DateTimeOffset' | 167.86 us | 0.8722 us | 0.7283 us |   7.32 |     0.04 | 0.9766 |   1.81 KB |
 | 'Get UnixTime with nanoseconds' | 170.21 us | 1.3889 us | 1.1598 us |   7.42 |     0.06 | 0.9440 |    1.8 KB |
