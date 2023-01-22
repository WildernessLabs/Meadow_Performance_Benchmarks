using System;
using System.Threading;
using Meadow.Hardware;

namespace Basic_Performance_Tests
{
    public static class SoftPwmPerformanceTests
    {
        static SoftPwmPerformanceTests()
        {
        }

        public static void RunSoftPwmTests()
        {
            IDigitalOutputPort digitalOut = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.OnboardLedGreen);
            SoftPwmPort softPwmPort = new SoftPwmPort(digitalOut);

            // 50% duty cycle
            softPwmPort.DutyCycle = 0.5f;

            Console.WriteLine("Testing port at 10hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(10, Meadow.Units.Frequency.UnitType.Hertz);
            softPwmPort.Start();
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 25hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(25, Meadow.Units.Frequency.UnitType.Hertz);
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 50hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(50, Meadow.Units.Frequency.UnitType.Hertz);
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 100hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(100, Meadow.Units.Frequency.UnitType.Hertz);
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 250hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(250, Meadow.Units.Frequency.UnitType.Hertz);
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 500hz");
            softPwmPort.Frequency = new Meadow.Units.Frequency(500, Meadow.Units.Frequency.UnitType.Hertz);
            Thread.Sleep(2000);

            softPwmPort.Stop();
        }
    }
}