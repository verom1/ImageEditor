using System.Drawing;

namespace ImageEditorApp.Services
{
    public static class ImageProcessor
    {
        // Простейший фільтр: відтінки сірого (grayscale)
        public static Bitmap ApplyGrayscale(Bitmap source)
        {
            var bmp = new Bitmap(source.Width, source.Height);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    var px = source.GetPixel(x, y);
                    var gray = (int)(0.3 * px.R + 0.59 * px.G + 0.11 * px.B);
                    var c = Color.FromArgb(px.A, gray, gray, gray);
                    bmp.SetPixel(x, y, c);
                }
            }
            return bmp;
        }

        // Інші операції (crop, resize) можна додати тут
    }
}
