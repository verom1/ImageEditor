using System.Drawing;

namespace ImageEditorApp.Tools
{
    public class ScaleTool
    {
        public Bitmap Resize(Bitmap bmp, int newW, int newH)
        {
            Bitmap resized = new Bitmap(newW, newH);

            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, 0, 0, newW, newH);
            }

            return resized;
        }
    }
}
