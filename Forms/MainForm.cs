using System;
using System.Windows.Forms;
using ImageEditorApp.Services;

namespace ImageEditorApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly ImageService _imageService;
        private readonly FilterService _filterService;

        public MainForm(ImageService imageService, FilterService filterService)
        {
            InitializeComponent();
            _imageService = imageService;
            _filterService = filterService;
        }

        private void btnOpenEditor_Click(object sender, EventArgs e)
        {
            var editorForm = new ImageEditorForm(_imageService, _filterService);
            editorForm.ShowDialog();
        }

        private void btnFilterLibrary_Click(object sender, EventArgs e)
        {
            var filterForm = new FilterLibraryForm(_filterService);
            filterForm.ShowDialog();
        }
    }
}
