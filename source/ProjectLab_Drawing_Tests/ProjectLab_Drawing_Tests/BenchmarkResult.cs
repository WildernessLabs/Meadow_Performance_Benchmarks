using System;

namespace ProjectLab_Drawing_Tests;

internal record struct BenchmarkResult(string Name, int NumberOfFrames, TimeSpan Elapsed);
