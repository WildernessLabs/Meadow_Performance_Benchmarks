using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Graphics;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProjectLab_Drawing_Tests;

public class MeadowApp : App<F7CoreComputeV2>
{
    MicroGraphics graphics;

    public override Task Initialize()
    {
        Console.WriteLine("Initialize...");

        var projLab = ProjectLab.Create();

        graphics = new MicroGraphics(projLab.Display);

        return Task.CompletedTask;
    }

    public override Task Run()
    {
        Console.WriteLine("Run...");

        RunBenchmark(new PartialShowBenchmark());
        RunBenchmark(new FillBenchmark());
        RunBenchmark(new StarfieldBenchmark());

        return Task.CompletedTask;
    }

    void RunBenchmark(IBenchmark benchmark, int frames = 100)
    {
        benchmark.Initialize(graphics);

        Stopwatch stopwatch = new();

        Console.Write($"{benchmark.Name}");
        stopwatch.Start();
        benchmark.Run(frames);
        stopwatch.Stop();

        Console.Write($"- {frames / stopwatch.Elapsed.TotalSeconds:n1}fps");
        Console.WriteLine();
    }
}