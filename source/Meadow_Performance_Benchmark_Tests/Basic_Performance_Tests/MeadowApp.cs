using Meadow;
using Meadow.Devices;
using System;
using System.Threading.Tasks;

namespace Basic_Performance_Tests
{
    // Original was App<F7FeatherV1>; bumped to F7CoreComputeV2 so this runs on
    // the ProjectLab + .NET 10 Mono builds we're benchmarking against the
    // legacy 2.x numbers in the README.
    public class MeadowApp : App<F7CoreComputeV2>
    {
        public override Task Run()
        {
            Console.WriteLine("App Up");
            ListOperations.RunIntegerListTests();
            DigitalOutputOperations.RunDigitalOutputTests();
            SoftPwmPerformanceTests.RunSoftPwmTests();
            PiCalculationTests.CalculateTo(50);
            PiCalculationTests.CalculateTo(100);
            PiCalculationTests.CalculateTo(150);
            Console.WriteLine("=== BENCH DONE ===");

            int beat = 0;
            while (true)
            {
                Console.WriteLine($"BEAT {beat++}");
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
