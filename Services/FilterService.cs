using System.Collections.Generic;
using System.Drawing;
using ImageEditorApp.Models;
using ImageEditorApp.Repositories;

namespace ImageEditorApp.Services
{
    public class FilterService
    {
        private readonly FilterRepository _filterRepository;

        public FilterService(FilterRepository filterRepository)
        {
            _filterRepository = filterRepository;
        }

        public IEnumerable<Filter> GetAllFilters() => _filterRepository.GetAll();

        public Bitmap ApplyFilter(Bitmap image, Filter filter)
        {
            Bitmap result = (Bitmap)image.Clone();

            if(filter.Name == "Invert")
            {
                for(int y = 0; y < result.Height; y++)
                {
                    for(int x = 0; x < result.Width; x++)
                    {
                        Color p = result.GetPixel(x, y);
                        Color np = Color.FromArgb(255 - p.R, 255 - p.G, 255 - p.B);
                        result.SetPixel(x, y, np);
                    }
                }
            }

            return result;
        }
    }
}
