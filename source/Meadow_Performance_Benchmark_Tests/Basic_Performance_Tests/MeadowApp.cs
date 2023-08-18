﻿using Meadow;
using Meadow.Devices;
using System;
using System.Threading.Tasks;

namespace Basic_Performance_Tests
{
    public class MeadowApp : App<F7FeatherV1>
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