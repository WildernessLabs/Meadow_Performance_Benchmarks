using System;
using System.Threading;
using Meadow.Foundation;
using Meadow.Foundation.Generators;
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
            softPwmPort.Frequency = 10;
            softPwmPort.Start();
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 25hz");
            softPwmPort.Frequency = 25;
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 50hz");
            softPwmPort.Frequency = 50;
            Thread.Sleep(2000);

            Console.WriteLine("Testing port at 100hz");
            softPwmPort.Frequency = 100;
            Thread.Sleep(2000);

            softPwmPort.Stop();

        }
    }
}
