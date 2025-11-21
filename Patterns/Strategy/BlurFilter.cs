using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class BlurFilter : IImageFilter
    {
        public string Name => "Blur";
        public Bitmap Apply(Bitmap source)
        {
            int radius = 1; // box size 3x3
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
            {
                for (int y = 0; y < source.Height; y++)
                {
                    int r = 0, g = 0, b = 0, count = 0;
                    for (int ix = x - radius; ix <= x + radius; ix++)
                    {
                        for (int iy = y - radius; iy <= y + radius; iy++)
                        {
                            if (ix >= 0 && ix < source.Width && iy >= 0 && iy < source.Height)
                            {
                                Color c = source.GetPixel(ix, iy);
                                r += c.R; g += c.G; b += c.B; count++;
                            }
                        }
                    }
                    bmp.SetPixel(x, y, Color.FromArgb(r / count, g / count, b / count));
                }
            }
            return bmp;
        }
    }
}
