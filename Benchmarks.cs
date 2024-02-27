using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace LazySplitString;

[MediumRunJob]
public class Benchmarks
{
    private const string Input = "Column1,Column2,Column3";
    
    private readonly IReadOnlyCollection<string> _precalculated = Calculate();

    private readonly Lazy<IReadOnlyCollection<string>> _lazy = new(Calculate);

    [Benchmark]
    public void ReadPrecalculated()
    {
        var result = _precalculated;
    }

    [Benchmark]
    public void ReadLazy()
    {
        var result = _lazy.Value;
    }

    [Benchmark]
    public void Recalculate()
    {
        var result = Calculate();
    }

    private static IReadOnlyCollection<string> Calculate() => Input.Split(',');
}
