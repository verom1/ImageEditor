using System.Drawing;
using System.IO;

public class ImageRepository
{
    private string folderPath = "Images";

    public Image LoadImage(string fileName)
    {
        string path = Path.Combine(folderPath, fileName);
        if (!File.Exists(path))
            return null;

        return Image.FromFile(path);
    }
}
