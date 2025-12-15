using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class FillBenchmark : IBenchmark
{
    public string Name => "Fill";

    private MicroGraphics graphics;

    public void Initialize(MicroGraphics Graphics)
    {
        graphics = Graphics ?? throw new ArgumentNullException(nameof(Graphics));
    }

    public void Run(int numberOfFrames)
    {
        Color color = Color.Cyan;

        for (int frame = 0; frame < numberOfFrames; frame++)
        {
            graphics.Clear(color, true);
            color = color.WithHue(color.Hue + 0.02f);
        }
    }
}