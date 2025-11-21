using System.Drawing;

namespace ImageEditorApp.Tools
{
    public class RotateTool
    {
        public Bitmap Rotate90(Bitmap bmp)
        {
            Bitmap clone = (Bitmap)bmp.Clone();
            clone.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return clone;
        }

        public Bitmap Rotate180(Bitmap bmp)
        {
            Bitmap clone = (Bitmap)bmp.Clone();
            clone.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return clone;
        }

        public Bitmap FlipHorizontal(Bitmap bmp)
        {
            Bitmap clone = (Bitmap)bmp.Clone();
            clone.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return clone;
        }
    }
}
