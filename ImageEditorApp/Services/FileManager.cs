using System;
using System.Drawing;
using System.IO;

namespace ImageEditorApp.Services
{
    public static class FileManager
    {
        public static Image LoadImage(string path)
        {
            // Безпечне завантаження копії
            using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var img = Image.FromStream(fs);
            return new Bitmap(img); // повернути копію в пам'яті
        }

        public static void SaveImage(Image image, string path)
        {
            var ext = Path.GetExtension(path).ToLowerInvariant();
            var format = ext switch
            {
                ".png" => System.Drawing.Imaging.ImageFormat.Png,
                ".bmp" => System.Drawing.Imaging.ImageFormat.Bmp,
                _ => System.Drawing.Imaging.ImageFormat.Jpeg
            };
            image.Save(path, format);
        }
    }
}
