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

            // init some ports — F7CoreComputeV2 doesn't expose OnboardLedRGB
            // pins like the Feather did, so use three arbitrary free GPIOs.
            IDigitalOutputPort red = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.PA0);
            IDigitalOutputPort green = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.PA3);
            IDigitalOutputPort blue = MeadowApp.Device.CreateDigitalOutputPort(MeadowApp.Device.Pins.PA9);

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

            // ── Same 100×3 alternation via the raw-BSRR escape hatch.
            // F7DigitalOutputPort.GetRawWriteHandle hands back a pointer to the
            // STM32 BSRR register and the set/clear masks for each pin, so the
            // hot loop is just three back-to-back register stores per iteration.
            if (red is F7DigitalOutputPort r &&
                green is F7DigitalOutputPort g &&
                blue is F7DigitalOutputPort b)
            {
                unsafe
                {
                    r.GetRawWriteHandle(out uint* rBsrr, out uint rSet, out uint rClear);
                    g.GetRawWriteHandle(out uint* gBsrr, out uint gSet, out uint gClear);
                    b.GetRawWriteHandle(out uint* bBsrr, out uint bSet, out uint bClear);

                    long rawStart = stopwatch.ElapsedMilliseconds;
                    bool rawState = false;
                    for (int i = 0; i < writeLoopCount; i++)
                    {
                        rawState = !rawState;
                        *rBsrr = rawState ? rSet : rClear;
                        *gBsrr = rawState ? gSet : gClear;
                        *bBsrr = rawState ? bSet : bClear;
                    }
                    long timeToWriteRaw = stopwatch.ElapsedMilliseconds - rawStart;
                    float avgRaw = (float)timeToWriteRaw / (float)(writeLoopCount * 3);

                    Console.WriteLine("=======================================");
                    Console.WriteLine($"Raw BSRR Port Test Results (F7DigitalOutputPort.GetRawWriteHandle):");
                    Console.WriteLine($"| {writeLoopCount * 3} Raw Port writes | {timeToWriteRaw}ms |");
                    Console.WriteLine($"| Raw avg time per write | {avgRaw}ms |");
                    Console.WriteLine("=======================================");
                }
            }
            else
            {
                Console.WriteLine("(skipping raw BSRR test — ports are not F7DigitalOutputPort)");
            }

            // cleanup
            red.Dispose();
            green.Dispose();
            blue.Dispose();
        }
    }
}