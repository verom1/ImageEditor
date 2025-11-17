using ImageEditorApp.Data;
using ImageEditorApp.Models;
using ImageEditorApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageEditorApp
{
    public class MainForm : Form
    {
        private Button btnOpen;
        private Button btnGrayscale;
        private Button btnSave;
        private PictureBox pictureBox;
        private Label lblStatus;

        private Bitmap currentBitmap;
        private string currentPath;

        private readonly AppDbContext _db;
        private readonly ImageRepository _imageRepo;
        private readonly HistoryService _historyService;

        public MainForm()
        {
            Text = "Редактор зображень";
            Width = 1000;
            Height = 700;

            btnOpen = new Button { Text = "Відкрити", Left = 10, Top = 10, Width = 90 };
            btnGrayscale = new Button { Text = "Ч/Б", Left = 110, Top = 10, Width = 90, Enabled = false };
            btnSave = new Button { Text = "Зберегти як...", Left = 210, Top = 10, Width = 120, Enabled = false };

            pictureBox = new PictureBox { Left = 10, Top = 50, Width = 960, Height = 580, BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            lblStatus = new Label { Left = 350, Top = 15, Width = 600 };

            Controls.Add(btnOpen);
            Controls.Add(btnGrayscale);
            Controls.Add(btnSave);
            Controls.Add(pictureBox);
            Controls.Add(lblStatus);

            btnOpen.Click += BtnOpen_Click;
            btnGrayscale.Click += BtnGrayscale_Click;
            btnSave.Click += BtnSave_Click;

            // DB init
            _db = new AppDbContext();
            _db.Database.EnsureCreated(); // створити БД якщо немає
            _imageRepo = new ImageRepository(_db);
            _historyService = new HistoryService(_db);
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Відкрити зображення"
            };

            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var fi = new FileInfo(ofd.FileName);
                if (fi.Length > 50 * 1024 * 1024) // 50 MB
                {
                    MessageBox.Show("Файл завеликий (понад 50 МБ).", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // завантажити
                var img = FileManager.LoadImage(ofd.FileName) as Bitmap;
                currentBitmap?.Dispose();
                currentBitmap = img;
                currentPath = ofd.FileName;
                pictureBox.Image = currentBitmap;
                btnGrayscale.Enabled = true;
                btnSave.Enabled = true;
                lblStatus.Text = $"Відкрито: {Path.GetFileName(currentPath)}";

                // Запис в БД (ImageRecord)
                var existing = _imageRepo.GetByPath(currentPath);
                if (existing == null)
                {
                    existing = new ImageRecord
                    {
                        FileName = Path.GetFileName(currentPath),
                        FilePath = currentPath,
                        CreatedAt = DateTime.Now
                    };
                    _imageRepo.Add(existing);
                    _imageRepo.Save();
                }
                _historyService.RecordAction(existing, "Open");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неможливо відкрити зображення: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGrayscale_Click(object sender, EventArgs e)
        {
            if (currentBitmap == null) return;

            try
            {
                var processed = ImageProcessor.ApplyGrayscale(currentBitmap);
                currentBitmap.Dispose();
                currentBitmap = processed;
                pictureBox.Image = currentBitmap;
                lblStatus.Text = "Застосовано: Чорно-білий фільтр";

                var record = _imageRepo.GetByPath(currentPath);
                _historyService.RecordAction(record, "Edit_Grayscale");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка обробки: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (currentBitmap == null) return;

            using var sfd = new SaveFileDialog
            {
                Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp",
                FileName = Path.GetFileNameWithoutExtension(currentPath) + "_edited"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                FileManager.SaveImage(currentBitmap, sfd.FileName);
                lblStatus.Text = $"Збережено: {Path.GetFileName(sfd.FileName)}";

                // оновити БД (новий record)
                var rec = new ImageRecord
                {
                    FileName = Path.GetFileName(sfd.FileName),
                    FilePath = sfd.FileName,
                    CreatedAt = DateTime.Now
                };
                _imageRepo.Add(rec);
                _imageRepo.Save();
                _historyService.RecordAction(rec, "Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            currentBitmap?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
