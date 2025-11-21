using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class GrayscaleFilter : IImageFilter
    {
        public string Name => "Grayscale";
        public Bitmap Apply(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    int l = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    bmp.SetPixel(x, y, Color.FromArgb(l, l, l));
                }
            return bmp;
        }
    }
}
