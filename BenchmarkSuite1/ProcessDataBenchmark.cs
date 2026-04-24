using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.VSDiagnostics;

[CPUUsageDiagnoser]
public class ProcessDataBenchmark
{
    private List<int> _data;
    [GlobalSetup]
    public void Setup()
    {
        var rand = new Random(42);
        _data = Enumerable.Range(0, 1_000_000).Select(_ => rand.Next(1, 1000)).ToList();
    }

    [Benchmark]
    public int ProcessData_Current()
    {
        var query = _data.Where(x => x % 2 == 0 && x > 500);
        var count = query.Count();
        var max = query.Max();
        var sum = query.Sum();
        return count + max + sum;
    }
}