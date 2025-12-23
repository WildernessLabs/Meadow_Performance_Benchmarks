using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class RotationBenchmark : IBenchmark
{
    public string Name => "Rotation";

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

            double angle = frame * 0.157; // ~9 degrees per frame in radians
            int centerX = 160;
            int centerY = 120;

            // Draw rotating shapes by calculating their positions
            // Simulate rotation with animated shapes moving in circles
            
            // First set of shapes rotating clockwise
            for (int i = 0; i < 8; i++)
            {
                double shapeAngle = angle + (i * Math.PI / 4);
                int x = centerX + (int)(60 * Math.Cos(shapeAngle));
                int y = centerY + (int)(60 * Math.Sin(shapeAngle));
                graphics.DrawRectangle(x - 5, y - 5, 10, 10, Color.Red, true);
            }

            // Second set of shapes rotating counter-clockwise
            for (int i = 0; i < 6; i++)
            {
                double shapeAngle = -angle + (i * Math.PI / 3);
                int x = centerX + (int)(40 * Math.Cos(shapeAngle));
                int y = centerY + (int)(40 * Math.Sin(shapeAngle));
                graphics.DrawCircle(x, y, 8, Color.Cyan, true);
            }

            // Third set - triangles rotating
            for (int i = 0; i < 4; i++)
            {
                double shapeAngle = angle * 2 + (i * Math.PI / 2);
                int x = centerX + (int)(80 * Math.Cos(shapeAngle));
                int y = centerY + (int)(80 * Math.Sin(shapeAngle));
                graphics.DrawTriangle(x, y - 7, x - 6, y + 7, x + 6, y + 7, Color.Yellow, true);
            }

            // Draw center marker
            graphics.DrawCircle(centerX, centerY, 5, Color.White, true);

            // Draw text showing frame count
            graphics.CurrentFont = new Font8x12();
            graphics.DrawText(10, 10, $"Frame: {frame}", Color.White);

            graphics.Show();
        }
    }
}
