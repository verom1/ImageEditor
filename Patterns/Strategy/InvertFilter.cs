using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class InvertFilter : IImageFilter
    {
        public string Name => "Invert";
        public Bitmap Apply(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            return bmp;
        }
    }
}
