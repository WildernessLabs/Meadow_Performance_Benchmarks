using System;
using Meadow.Hardware;

namespace Basic_Performance_Tests
{
    public static class DigitalOutputOperations
    {
        static DigitalOutputOperations()
        {
        }

        public static void RunDigitalOutputTests()
        {
            // setup our timer
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            long elapsedTimePortsCreated;
            long elapsedTimePortsWritten;

            bool state = false;
            int writeLoopCount = 100;

            stopwatch.Start();

            // init some ports
            IDigitalOutputPort red = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.OnboardLedRed);
            IDigitalOutputPort green = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.OnboardLedGreen);
            IDigitalOutputPort blue = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.OnboardLedBlue);

            elapsedTimePortsCreated = stopwatch.ElapsedMilliseconds;

            // write to the ports
            for (int i = 0; i < writeLoopCount; i++) 
            {
                state = !state;
                red.State = state;
                green.State = state;
                blue.State = state;
            }
            elapsedTimePortsWritten = stopwatch.ElapsedMilliseconds;

            // calculate times.
            long timeToWrite = elapsedTimePortsWritten - elapsedTimePortsCreated;
            float averageWriteTime = (float)timeToWrite / (float)(writeLoopCount * 3);

            // output
            Console.WriteLine("=======================================");
            Console.WriteLine($"Port Test Results:");
            Console.WriteLine($"| Port initialization | {elapsedTimePortsCreated}ms |");
            Console.WriteLine($"| {writeLoopCount * 3} Port writes | {timeToWrite}ms |");
            Console.WriteLine($"| Average time per write | {averageWriteTime}ms |");
            Console.WriteLine("=======================================");

            // cleanup
            red.Dispose();
            green.Dispose();
            blue.Dispose();
        }
    }
}