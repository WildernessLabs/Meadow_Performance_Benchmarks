using Meadow.Foundation.Graphics;

namespace ProjectLab_Drawing_Tests;

internal interface IBenchmark
{
    public string Name { get; }

    public void Initialize(MicroGraphics Graphics);
    public void Run(int numberOfFrames);
    public void Cleanup() { }  // Default empty implementation for resource cleanup
}