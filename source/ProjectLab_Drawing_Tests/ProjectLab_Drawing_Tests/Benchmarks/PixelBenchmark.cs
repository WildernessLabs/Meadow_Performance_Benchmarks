using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

public class PixelBenchmark : IBenchmark
{
    public string Name => "Pixel";

    private MicroGraphics graphics;

    public void Initialize(MicroGraphics Graphics)
    {
        graphics = Graphics ?? throw new ArgumentNullException(nameof(Graphics));
    }

    public void Run(int numberOfFrames)
    {
        graphics.Clear();

        for (int i = 0; i < numberOfFrames; i++)
        {
            graphics.DrawPixel(i % graphics.Width, i / graphics.Height, Color.White);
            graphics.Show();
        }
    }
}