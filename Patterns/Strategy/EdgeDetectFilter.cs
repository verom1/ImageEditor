using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class EdgeDetectFilter : IImageFilter
    {
        public string Name => "EdgeDetect";
        private int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
        private int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

        public Bitmap Apply(Bitmap source)
        {
            int w = source.Width, h = source.Height;
            Bitmap bmp = new Bitmap(w, h);
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    double rx = 0, gxv = 0, bx = 0;
                    double ry = 0, gyv2 = 0, by = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                        {
                            int ix = x + i, iy = y + j;
                            if (ix >= 0 && ix < w && iy >= 0 && iy < h)
                            {
                                Color c = source.GetPixel(ix, iy);
                                int kx = gx[i + 1, j + 1];
                                int ky = gy[i + 1, j + 1];
                                rx += c.R * kx; ry += c.R * ky;
                                gxv += c.G * kx; gyv2 += c.G * ky;
                                bx += c.B * kx; by += c.B * ky;
                            }
                        }
                    int r = Clamp((int)System.Math.Sqrt(rx * rx + ry * ry));
                    int g = Clamp((int)System.Math.Sqrt(gxv * gxv + gyv2 * gyv2));
                    int b = Clamp((int)System.Math.Sqrt(bx * bx + by * by));
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            return bmp;
        }

        private int Clamp(int v) => v < 0 ? 0 : (v > 255 ? 255 : v);
    }
}
