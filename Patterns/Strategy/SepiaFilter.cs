using System.Drawing;

namespace ImageEditorApp.Patterns.Strategy
{
    public class SepiaFilter : IImageFilter
    {
        public string Name => "Sepia";
        public Bitmap Apply(Bitmap source)
        {
            Bitmap bmp = new Bitmap(source.Width, source.Height);
            for (int x = 0; x < source.Width; x++)
                for (int y = 0; y < source.Height; y++)
                {
                    Color c = source.GetPixel(x, y);
                    int tr = (int)(0.393 * c.R + 0.769 * c.G + 0.189 * c.B);
                    int tg = (int)(0.349 * c.R + 0.686 * c.G + 0.168 * c.B);
                    int tb = (int)(0.272 * c.R + 0.534 * c.G + 0.131 * c.B);
                    tr = tr > 255 ? 255 : tr;
                    tg = tg > 255 ? 255 : tg;
                    tb = tb > 255 ? 255 : tb;
                    bmp.SetPixel(x, y, Color.FromArgb(tr, tg, tb));
                }
            return bmp;
        }
    }
}
