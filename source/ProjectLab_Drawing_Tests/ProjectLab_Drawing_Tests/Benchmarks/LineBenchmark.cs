using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class LineBenchmark : IBenchmark
{
    public string Name => "Line";

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

            int offset = frame % 20;

            // Horizontal lines
            graphics.Stroke = 1;
            graphics.DrawHorizontalLine(10 + offset, 20, 100, Color.Red);
            graphics.DrawHorizontalLine(10 + offset, 40, 120, Color.Orange);
            
            graphics.Stroke = 2;
            graphics.DrawHorizontalLine(10 + offset, 60, 140, Color.Yellow);
            
            graphics.Stroke = 3;
            graphics.DrawHorizontalLine(10 + offset, 80, 160, Color.LawnGreen);

            // Vertical lines
            graphics.Stroke = 1;
            graphics.DrawVerticalLine(180 + offset, 20, 80, Color.Cyan);
            graphics.DrawVerticalLine(200 + offset, 20, 80, Color.Blue);
            
            graphics.Stroke = 2;
            graphics.DrawVerticalLine(220 + offset, 20, 80, Color.Purple);
            
            graphics.Stroke = 3;
            graphics.DrawVerticalLine(240 + offset, 20, 80, Color.Magenta);

            // Diagonal lines
            graphics.Stroke = 1;
            graphics.DrawLine(10 + offset, 110, 100 + offset, 180, Color.White);
            graphics.DrawLine(110 + offset, 110, 20 + offset, 180, Color.Gray);
            
            graphics.Stroke = 2;
            graphics.DrawLine(120 + offset, 110, 200 + offset, 180, Color.Cyan);
            graphics.DrawLine(210 + offset, 110, 130 + offset, 180, Color.Yellow);

            graphics.Stroke = 3;
            graphics.DrawLine(220 + offset, 110, 290 + offset, 180, Color.Red);

            graphics.Show();
        }
    }

    public void Cleanup()
    {
        // Reset stroke to default
        graphics.Stroke = 1;
    }
}
