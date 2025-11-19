namespace ImageEditorApp.Forms
{
    partial class EditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnApplyBrightness;
        private System.Windows.Forms.Button btnCropImage;
        private System.Windows.Forms.Button btnShowHistory;
        private System.Windows.Forms.ListBox lstEditHistory;

        private void InitializeComponent()
        {
            this.btnApplyBrightness = new System.Windows.Forms.Button();
            this.btnCropImage = new System.Windows.Forms.Button();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.lstEditHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            // 
            // btnApplyBrightness
            // 
            this.btnApplyBrightness.Location = new System.Drawing.Point(12, 12);
            this.btnApplyBrightness.Name = "btnApplyBrightness";
            this.btnApplyBrightness.Size = new System.Drawing.Size(150, 30);
            this.btnApplyBrightness.Text = "Змінити яскравість";
            this.btnApplyBrightness.Click += new System.EventHandler(this.btnApplyBrightness_Click);

            // 
            // btnCropImage
            // 
            this.btnCropImage.Location = new System.Drawing.Point(12, 48);
            this.btnCropImage.Name = "btnCropImage";
            this.btnCropImage.Size = new System.Drawing.Size(150, 30);
            this.btnCropImage.Text = "Обрізати зображення";
            this.btnCropImage.Click += new System.EventHandler(this.btnCropImage_Click);

            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Location = new System.Drawing.Point(12, 84);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(150, 30);
            this.btnShowHistory.Text = "Показати історію";
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);

            // 
            // lstEditHistory
            // 
            this.lstEditHistory.Location = new System.Drawing.Point(180, 12);
            this.lstEditHistory.Name = "lstEditHistory";
            this.lstEditHistory.Size = new System.Drawing.Size(250, 200);

            // 
            // EditForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.Controls.Add(this.btnApplyBrightness);
            this.Controls.Add(this.btnCropImage);
            this.Controls.Add(this.btnShowHistory);
            this.Controls.Add(this.lstEditHistory);
            this.Name = "EditForm";
            this.Text = "Редактор зображень";
            this.ResumeLayout(false);
        }
    }
}
