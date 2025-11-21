using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public interface IImageFilter
    {
        Bitmap Apply(Bitmap source);
        string Name { get; }
    }
}
