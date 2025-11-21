using System;
using System.Drawing;
using System.Windows.Forms;
using ImageEditorApp.Services;
using ImageEditorApp.Patterns.Command;
using ImageEditorApp.Patterns.Strategy;
using ImageEditorApp.Patterns.Singleton;

namespace ImageEditorApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly EditingService _editingService = new EditingService();
        private readonly CommandManager _cmdManager = new CommandManager();

        public MainForm()
        {
            InitializeComponent();
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp";
                dlg.InitialDirectory = AppSettings.Instance.LastOpenFolder;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(dlg.FileName);
                    _editingService.SetCurrentBitmap(bmp);
                    pictureBox.Image = bmp;
                    AppSettings.Instance.LastOpenFolder = System.IO.Path.GetDirectoryName(dlg.FileName);
                    _editingService.AddHistory("Opened image");
                }
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            if (_editingService.GetCurrentBitmap() == null) { MessageBox.Show("No image"); return; }
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PNG|*.png";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _editingService.GetCurrentBitmap().Save(dlg.FileName);
                    MessageBox.Show("Saved");
                }
            }
        }

        private void tsUndo_Click(object sender, EventArgs e)
        {
            _cmdManager.Undo();
            pictureBox.Image = _editingService.GetCurrentBitmap();
        }

        private void tsRedo_Click(object sender, EventArgs e)
        {
            _cmdManager.Redo();
            pictureBox.Image = _editingService.GetCurrentBitmap();
        }

        // Відкриття вікна фільтрів
        private void OpenFiltersAndApply(IImageFilter filter)
        {
            if (_editingService.GetCurrentBitmap() == null) { MessageBox.Show("Open image first"); return; }
            var cmd = new ApplyFilterCommand(_editingService, filter);
            _cmdManager.Execute(cmd);
            pictureBox.Image = _editingService.GetCurrentBitmap();
        }

        // Для прикладу: виклики фільтрів можна прив'язати до меню або кнопок
        // Наприклад, створимо кілька простих кнопок прямо в меню: (для компактності не показую окремі кнопки)
    }
}

