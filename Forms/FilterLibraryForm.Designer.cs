namespace ImageEditorApp.Forms
{
    partial class FilterLibraryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboFilters;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboFilters = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // comboFilters
            this.comboFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilters.Location = new System.Drawing.Point(15, 15);
            this.comboFilters.Size = new System.Drawing.Size(260, 25);

            // btnApply
            this.btnApply.Text = "Apply";
            this.btnApply.Location = new System.Drawing.Point(15, 55);
            this.btnApply.Size = new System.Drawing.Size(120, 35);
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);

            // btnCancel
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(155, 55);
            this.btnCancel.Size = new System.Drawing.Size(120, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(295, 110);
            this.Controls.Add(this.comboFilters);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Filter Library";
        }
    }
}
