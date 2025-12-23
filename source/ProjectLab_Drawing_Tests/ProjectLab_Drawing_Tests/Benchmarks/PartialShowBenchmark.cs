using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class PartialShowBenchmark : IBenchmark
{
    public string Name => "PartialShow";

    private MicroGraphics graphics;

    public void Initialize(MicroGraphics Graphics)
    {
        graphics = Graphics ?? throw new ArgumentNullException(nameof(Graphics));
    }

    public void Run(int numberOfFrames)
    {
        while (true)
        {
            graphics.Clear(true);
            graphics.DrawRectangle(0, 0, 320, 240, Color.Teal, true);

            for (int x = 0; x < 200; x += 20)
            {
                for (int y = 0; y < 200; y += 20)
                {
                    graphics.Show(x, y, x + 20, y + 20);
                    numberOfFrames--;
                    if (numberOfFrames == 0)
                    {
                        return;
                    }
                }
            }
        }
    }
}