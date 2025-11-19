using System;
using System.Windows.Forms;
using ImageEditorApp.Models;
using ImageEditorApp.Services;

namespace ImageEditorApp.Forms
{
    public partial class EditForm : Form
    {
        private EditingService editingService;

        public EditForm()
        {
            InitializeComponent();
            editingService = new EditingService();
        }

        private void btnApplyBrightness_Click(object sender, EventArgs e)
        {
            editingService.ApplyEdit(new EditHistory { Description = "Змінив яскравість" });
            MessageBox.Show("Застосовано зміну яскравості");
        }

        private void btnCropImage_Click(object sender, EventArgs e)
        {
            editingService.ApplyEdit(new EditHistory { Description = "Обрізав зображення" });
            MessageBox.Show("Застосовано обрізку зображення");
        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            lstEditHistory.Items.Clear();

            var iterator = editingService.GetHistoryIterator();
            while (!iterator.IsDone())
            {
                lstEditHistory.Items.Add(iterator.Current().Description);
                iterator.Next();
            }
        }
    }
}

