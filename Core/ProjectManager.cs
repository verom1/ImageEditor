using System.IO;
using Newtonsoft.Json;
using System.Drawing;

namespace ImageEditorApp.Core
{
    public class ProjectManager
    {
        public void Save(ProjectState state, string path)
        {
            var data = new
            {
                state.OriginalPath,
                ImageBase64 = BitmapToBase64(state.CurrentBitmap)
            };

            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }

        public ProjectState Load(string path)
        {
            var json = File.ReadAllText(path);
            dynamic data = JsonConvert.DeserializeObject(json);

            return new ProjectState
            {
                OriginalPath = data.OriginalPath,
                CurrentBitmap = Base64ToBitmap((string)data.ImageBase64)
            };
        }

        private string BitmapToBase64(Bitmap bmp)
        {
            using var ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return Convert.ToBase64String(ms.ToArray());
        }

        private Bitmap Base64ToBitmap(string b64)
        {
            byte[] bytes = Convert.FromBase64String(b64);
            using var ms = new MemoryStream(bytes);
            return new Bitmap(ms);
        }
    }
}
