using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class ArcBenchmark : IBenchmark
{
    public string Name => "Arc";

    private MicroGraphics graphics;

    public void Initialize(MicroGraphics Graphics)
    {
        graphics = Graphics ?? throw new ArgumentNullException(nameof(Graphics));
    }

    public void Run(int numberOfFrames)
    {
        for (int frame = 0; frame < numberOfFrames; frame++)
        {
            graphics.Clear();

            int offset = frame % 40;

            // Draw circles with different sizes (concentric)
            graphics.DrawCircle(60, 60, 40, Color.Red);
            graphics.DrawCircle(60, 60, 35, Color.Orange);
            graphics.DrawCircle(60, 60, 30, Color.Yellow);
            graphics.DrawCircle(60, 60, 25, Color.LawnGreen);
            graphics.DrawCircle(60, 60, 20, Color.Cyan);

            // Draw filled circles
            graphics.DrawCircle(180, 60, 40, Color.Purple, true);
            graphics.DrawCircle(180, 60, 30, Color.Magenta, true);
            graphics.DrawCircle(180, 60, 20, Color.Blue, true);

            // Draw animated circles
            graphics.DrawCircle(60 + offset, 160, 30, Color.White);
            graphics.DrawCircle(140 + offset, 160, 35, Color.Cyan, true);
            graphics.DrawCircle(220 - offset, 160, 25, Color.Yellow);
            graphics.DrawCircle(280 - offset, 160, 30, Color.Red, true);

            // Draw multiple small circles
            for (int i = 0; i < 10; i++)
            {
                int x = 20 + i * 28;
                graphics.DrawCircle(x, 210, 12, Color.FromRgb((byte)(i * 25), 100, 255 - (byte)(i * 25)));
            }

            graphics.Show();
        }
    }
}
