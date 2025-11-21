using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageEditorApp.Patterns.Strategy
{
    public class FastGrayscaleFilter : IImageFilter
    {
        public string Name => "Grayscale (Fast)";

        public Bitmap Apply(Bitmap bmp)
        {
            Bitmap clone = new Bitmap(bmp.Width, bmp.Height);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData srcData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dstData = clone.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            int bytes = Math.Abs(srcData.Stride) * bmp.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];

            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);

            for (int i = 0; i < bytes; i += 3)
            {
                byte gray = (byte)(buffer[i] * 0.11 + buffer[i + 1] * 0.59 + buffer[i + 2] * 0.3);

                result[i] = result[i + 1] = result[i + 2] = gray;
            }

            Marshal.Copy(result, 0, dstData.Scan0, bytes);

            bmp.UnlockBits(srcData);
            clone.UnlockBits(dstData);

            return clone;
        }
    }
}
