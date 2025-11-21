using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditorApp.Forms
{
    public class CropForm : Form
    {
        private Bitmap _source;
        private PictureBox picture;
        private Rectangle selection;
        private bool mouseDown;
        public Bitmap ResultImage { get; private set; }

        public CropForm(Bitmap source)
        {
            _source = source;
            ResultImage = source;

            this.Width = 800;
            this.Height = 600;

            picture = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = source,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            picture.MouseDown += Picture_MouseDown;
            picture.MouseMove += Picture_MouseMove;
            picture.MouseUp += Picture_MouseUp;

            Controls.Add(picture);
        }

        private void Picture_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            selection = new Rectangle(e.X, e.Y, 0, 0);
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;

            selection.Width = e.X - selection.X;
            selection.Height = e.Y - selection.Y;
            picture.Refresh();
            picture.CreateGraphics().DrawRectangle(Pens.Red, selection);
        }

        private void Picture_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

            if (selection.Width <= 0 || selection.Height <= 0)
            {
                MessageBox.Show("Invalid region");
                return;
            }

            Bitmap bmp = new Bitmap(selection.Width, selection.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(_source, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    selection, GraphicsUnit.Pixel);
            }

            ResultImage = bmp;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
