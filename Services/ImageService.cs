using System;
using System.Collections.Generic;
using System.Drawing;
using ImageEditorApp.Models;
using ImageEditorApp.Repositories;

namespace ImageEditorApp.Services
{
    public class ImageService
    {
        private readonly ImageRepository _imageRepository;

        public ImageService(ImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Image LoadImage(int id) => _imageRepository.Get(id);
        public IEnumerable<Image> GetAllImages() => _imageRepository.GetAll();

        public void SaveImage(Image image)
        {
            if(image.Id == 0) _imageRepository.Add(image);
            else _imageRepository.Update(image);
        }

        public Bitmap ApplyEdits(Bitmap image, List<Func<Bitmap, Bitmap>> edits)
        {
            Bitmap result = (Bitmap)image.Clone();
            foreach(var edit in edits)
                result = edit(result);
            return result;
        }
    }
}
