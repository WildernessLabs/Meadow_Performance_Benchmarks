using Meadow;
using Meadow.Foundation.Graphics;
using System;

namespace ProjectLab_Drawing_Tests;

internal class TextBenchmark : IBenchmark
{
    public string Name => "Text";

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

            // Test different font sizes
            graphics.CurrentFont = new Font4x8();
            graphics.DrawText(10, 10, "Font4x8 Test", Color.White);
            graphics.DrawText(10, 20, "Left aligned", Color.Cyan, alignmentH: HorizontalAlignment.Left);

            graphics.CurrentFont = new Font8x12();
            graphics.DrawText(160, 40, "Font8x12 Center", Color.Yellow, alignmentH: HorizontalAlignment.Center);
            graphics.DrawText(160, 55, "Multiple", Color.LawnGreen, alignmentH: HorizontalAlignment.Center);
            graphics.DrawText(160, 70, "Lines", Color.LawnGreen, alignmentH: HorizontalAlignment.Center);

            graphics.CurrentFont = new Font12x16();
            graphics.DrawText(310, 90, "Font12x16", Color.Red, alignmentH: HorizontalAlignment.Right);
            graphics.DrawText(310, 110, "Right", Color.Orange, alignmentH: HorizontalAlignment.Right);

            graphics.CurrentFont = new Font8x12();
            graphics.DrawText(10, 130, "Performance", Color.Purple);
            graphics.DrawText(10, 145, "Benchmark", Color.Purple);
            graphics.DrawText(10, 160, "Text Rendering", Color.Purple);
            graphics.DrawText(10, 175, $"Frame {frame}", Color.White);

            graphics.Show();
        }
    }
}
