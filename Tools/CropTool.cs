using System.Drawing;
using System.Windows.Forms;

namespace ImageEditorApp.Tools
{
    public class CropTool
    {
        public Bitmap Crop(Bitmap source)
        {
            using (var form = new CropForm(source))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    return form.ResultImage;
            }

            return source;
        }
    }
}

