using Meadow;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.Buffers;
using Meadow.Peripherals.Displays;
using System;

namespace ProjectLab_Drawing_Tests;

internal class BufferOperationsBenchmark : IBenchmark
{
    private const int BufferWidth = 80;
    private const int BufferHeight = 60;

    public string Name => "BufferOps";

    private MicroGraphics graphics;
    private IPixelBuffer buffer1;
    private IPixelBuffer buffer2;

    public void Initialize(MicroGraphics Graphics)
    {
        graphics = Graphics ?? throw new ArgumentNullException(nameof(Graphics));

        // Create small buffers for testing
        buffer1 = new BufferRgb888(BufferWidth, BufferHeight);
        buffer2 = new BufferRgb888(BufferWidth, BufferHeight);

        // Fill buffer1 with a gradient pattern
        for (int y = 0; y < BufferHeight; y++)
        {
            for (int x = 0; x < BufferWidth; x++)
            {
                byte r = (byte)((x * 255) / BufferWidth);
                byte g = (byte)((y * 255) / BufferHeight);
                byte b = (byte)(((x + y) * 255) / (BufferWidth + BufferHeight));
                var color = Color.FromRgb(r, g, b);
                buffer1.SetPixel(x, y, color);
            }
        }

        // Fill buffer2 with a different pattern
        for (int y = 0; y < BufferHeight; y++)
        {
            for (int x = 0; x < BufferWidth; x++)
            {
                byte r = (byte)(255 - (x * 255) / BufferWidth);
                byte g = (byte)(128 + (y * 127) / BufferHeight);
                byte b = (byte)((x * 255) / BufferWidth);
                var color = Color.FromRgb(r, g, b);
                buffer2.SetPixel(x, y, color);
            }
        }
    }

    public void Run(int numberOfFrames)
    {
        for (int frame = 0; frame < numberOfFrames; frame++)
        {
            graphics.Clear();

            // Test WriteBuffer performance with different positions
            int offset = frame % 20;

            // Draw buffer1 at multiple positions
            graphics.DrawBuffer(10 + offset, 10, buffer1);
            graphics.DrawBuffer(100 + offset, 10, buffer1);
            graphics.DrawBuffer(190 + offset, 10, buffer1);

            // Draw buffer2 at multiple positions
            graphics.DrawBuffer(10 + offset, 80, buffer2);
            graphics.DrawBuffer(100 + offset, 80, buffer2);
            graphics.DrawBuffer(190 + offset, 80, buffer2);

            // Draw alternating buffers
            if (frame % 2 == 0)
            {
                graphics.DrawBuffer(10 + offset, 150, buffer1);
                graphics.DrawBuffer(100 + offset, 150, buffer2);
            }
            else
            {
                graphics.DrawBuffer(10 + offset, 150, buffer2);
                graphics.DrawBuffer(100 + offset, 150, buffer1);
            }

            graphics.Show();
        }
    }
}
