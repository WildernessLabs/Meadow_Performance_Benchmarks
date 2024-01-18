using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ProjectLab_Drawing_Tests;

public class MeadowApp : App<F7CoreComputeV2>
{
    List<BenchmarkResult> benchmarkResults;

    MicroGraphics graphics;

    public override Task Initialize()
    {
        Console.WriteLine("Initialize...");

        benchmarkResults = new List<BenchmarkResult>();

        var projLab = ProjectLab.Create();

        graphics = new MicroGraphics(projLab.Display);

        return Task.CompletedTask;
    }

    public override Task Run()
    {
        Console.WriteLine("Run benchmarks...");

        RunBenchmarks();

        ShowResults();

        return Task.CompletedTask;
    }

    void RunBenchmarks()
    {
        benchmarkResults.Add(RunBenchmark(new PathBenchmark()));
        benchmarkResults.Add(RunBenchmark(new PartialShowBenchmark()));
        benchmarkResults.Add(RunBenchmark(new StarfieldBenchmark()));
        benchmarkResults.Add(RunBenchmark(new FillBenchmark()));
        benchmarkResults.Add(RunBenchmark(new GradientFillBenchmark(), 25));
    }

    void ShowResults()
    {
        graphics.Clear();
        graphics.CurrentFont = new Font8x12();

        graphics.DrawText(0, 0, "Results", Color.LawnGreen);

        int y = 30;

        foreach (var result in benchmarkResults)
        {
            var fps = result.NumberOfFrames / result.Elapsed.TotalSeconds;

            graphics.DrawText(0, y, result.Name, Color.LawnGreen);
            graphics.DrawText(30, y, $"{fps:n2}fps", Color.LawnGreen);
            graphics.Show();

            y += 20;
        }

        graphics.Show();
    }

    BenchmarkResult RunBenchmark(IBenchmark benchmark, int frames = 100)
    {
        benchmark.Initialize(graphics);

        Stopwatch stopwatch = new();

        Console.Write($"{benchmark.Name}");
        stopwatch.Start();
        benchmark.Run(frames);
        stopwatch.Stop();

        var fps = frames / stopwatch.Elapsed.TotalSeconds;

        Console.WriteLine($"   {fps:n2}fps");
        return new BenchmarkResult(benchmark.Name, frames, stopwatch.Elapsed);
    }
}