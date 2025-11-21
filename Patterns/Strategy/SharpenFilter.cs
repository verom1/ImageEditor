using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class SharpenFilter : IImageFilter
    {
        public string Name => "Sharpen";
        private int[,] kernel = new int[,] {
            { 0, -1, 0},
            {-1, 5, -1},
            {0, -1, 0}
        };

        public Bitmap Apply(Bitmap source)
        {
            int w = source.Width, h = source.Height;
            Bitmap bmp = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    int r = 0, g = 0, b = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int ix = x + i, iy = y + j;
                            if (ix >= 0 && ix < w && iy >= 0 && iy < h)
                            {
                                Color c = source.GetPixel(ix, iy);
                                int k = kernel[i + 1, j + 1];
                                r += c.R * k; g += c.G * k; b += c.B * k;
                            }
                        }
                    r = Clamp(r); g = Clamp(g); b = Clamp(b);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            return bmp;
        }

        private int Clamp(int v) => v < 0 ? 0 : (v > 255 ? 255 : v);
    }
}
