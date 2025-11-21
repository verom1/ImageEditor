using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class EmbossFilter : IImageFilter
    {
        public string Name => "Emboss";
        private int[,] kernel = new int[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } };

        public Bitmap Apply(Bitmap source)
        {
            int w = source.Width, h = source.Height;
            Bitmap bmp = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    int r = 128, g = 128, b = 128; // center bias
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
                    bmp.SetPixel(x, y, Color.FromArgb(Clamp(r), Clamp(g), Clamp(b)));
                }
            return bmp;
        }

        private int Clamp(int v) => v < 0 ? 0 : (v > 255 ? 255 : v);
    }
}
