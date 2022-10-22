using System;
using System.Threading.Tasks;
using Meadow;
using Meadow.Devices;

namespace Basic_Performance_Tests
{
    public class MeadowApp : App<F7FeatherV2>
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

            return base.Run();
        }
    }
}