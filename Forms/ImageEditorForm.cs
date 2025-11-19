using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImageEditorApp.Models;
using ImageEditorApp.Services;

namespace ImageEditorApp.Forms
{
    public partial class ImageEditorForm : Form
    {
        private readonly ImageService _imageService;
        private readonly FilterService _filterService;
        private Bitmap _currentBitmap;

        public ImageEditorForm(ImageService imageService, FilterService filterService)
        {
            InitializeComponent();
            _imageService = imageService;
            _filterService = filterService;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images|*.png;*.jpg;*.jpeg";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    _currentBitmap = new Bitmap(dlg.FileName);
                    pictureBox1.Image = _currentBitmap;
                }
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            var filterForm = new FilterLibraryForm(_filterService);
            if(filterForm.ShowDialog() == DialogResult.OK)
            {
                var filter = filterForm.SelectedFilter;
                _currentBitmap = _filterService.ApplyFilter(_currentBitmap, filter);
                pictureBox1.Image = _currentBitmap;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PNG|*.png";
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    _currentBitmap.Save(dlg.FileName);
                    _imageService.SaveImage(new Image
                    {
                        Name = System.IO.Path.GetFileName(dlg.FileName),
                        FilePath = dlg.FileName,
                        DateAdded = DateTime.Now
                    });
                }
            }
        }
    }
}

