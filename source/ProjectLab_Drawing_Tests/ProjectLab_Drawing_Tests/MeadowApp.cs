using Meadow;
using Meadow.Devices;
using Meadow.Foundation.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
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
        benchmarkResults.Add(RunBenchmark(new PartialShowBenchmark(), 100));
        benchmarkResults.Add(RunBenchmark(new StarfieldBenchmark()));
        benchmarkResults.Add(RunBenchmark(new FillBenchmark()));
        benchmarkResults.Add(RunBenchmark(new GradientFillBenchmark(), 15));
        benchmarkResults.Add(RunBenchmark(new SpriteBenchmark()));
    }

    void ShowResults()
    {
        graphics.Clear();
        graphics.CurrentFont = new Font8x12();

        graphics.DrawText(0, 2, "Results", Color.LawnGreen);
        graphics.Show();

        TimeSpan totalElapsed = TimeSpan.Zero;

        int y = 30;

        foreach (var result in benchmarkResults)
        {
            Thread.Sleep(250);
            totalElapsed += result.Elapsed;

            var fps = result.NumberOfFrames / result.Elapsed.TotalSeconds;

            graphics.DrawText(0, y, result.Name, Color.LawnGreen);
            graphics.DrawText(180, y, $"{fps:n2}fps", Color.LawnGreen, alignmentH: HorizontalAlignment.Right);
            graphics.Show();

            y += 20;
        }

        y += 30;
        graphics.DrawText(0, y, "Total time", Color.LawnGreen);
        graphics.DrawText(180, y, $"{totalElapsed.TotalSeconds:n2}s", Color.LawnGreen, alignmentH: HorizontalAlignment.Right);

        graphics.Show();
    }

    BenchmarkResult RunBenchmark(IBenchmark benchmark, int frames = 40)
    {
        benchmark.Initialize(graphics);

        Stopwatch stopwatch = new();

        Console.WriteLine($"{benchmark.Name}");
        stopwatch.Start();
        benchmark.Run(frames);
        stopwatch.Stop();

        var fps = frames / stopwatch.Elapsed.TotalSeconds;

        Console.WriteLine($"   {fps:n2}fps");
        return new BenchmarkResult(benchmark.Name, frames, stopwatch.Elapsed);
    }

    public static byte[] LoadResource(string filename)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"ProjectLab_Drawing_Tests.{filename}";

        using Stream stream = assembly.GetManifestResourceStream(resourceName);
        using var ms = new MemoryStream();

        stream.CopyTo(ms);
        return ms.ToArray();
    }
}