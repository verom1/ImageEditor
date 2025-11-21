namespace ImageEditorApp.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tsOpen;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.ToolStripButton tsUndo;
        private System.Windows.Forms.ToolStripButton tsRedo;
        private System.Windows.Forms.PictureBox pictureBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsOpen = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.tsUndo = new System.Windows.Forms.ToolStripButton();
            this.tsRedo = new System.Windows.Forms.ToolStripButton();
            this.pictureBox = new System.Windows.Forms.PictureBox();

            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsOpen, this.tsSave, this.tsUndo, this.tsRedo
            });

            this.tsOpen.Text = "Open";
            this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);

            this.tsSave.Text = "Save";
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);

            this.tsUndo.Text = "Undo";
            this.tsUndo.Click += new System.EventHandler(this.tsUndo_Click);

            this.tsRedo.Text = "Redo";
            this.tsRedo.Click += new System.EventHandler(this.tsRedo_Click);

            this.pictureBox.Location = new System.Drawing.Point(12, 40);
            this.pictureBox.Size = new System.Drawing.Size(800, 600);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.ClientSize = new System.Drawing.Size(820, 660);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.toolStrip);
            this.Text = "Image Editor";
        }
    }
}
