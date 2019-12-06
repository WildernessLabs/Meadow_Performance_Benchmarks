using System;
using System.Collections.Generic;
using System.Threading;
using Meadow;
using Meadow.Devices;
using Meadow.Hardware;

namespace Basic_Performance_Tests
{
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        public MeadowApp()
        {
            Console.WriteLine("App Up");
            //ListOperations.RunIntegerListTests();
            //DigitalOutputOperations.RunDigitalOutputTests();
            //SoftPwmPerformanceTests.RunSoftPwmTests();
            PiCalculationTests.CalculateTo(50);
            PiCalculationTests.CalculateTo(100);
            PiCalculationTests.CalculateTo(150);
        }

    }
}