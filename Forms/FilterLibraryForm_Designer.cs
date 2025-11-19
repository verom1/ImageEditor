private System.Windows.Forms.ListBox listBoxFilters;


private void InitializeComponent()
{
    this.listBoxFilters = new System.Windows.Forms.ListBox();
    this.SuspendLayout();
    // 
    // listBoxFilters
    // 
    this.listBoxFilters.FormattingEnabled = true;
    this.listBoxFilters.ItemHeight = 16;
    this.listBoxFilters.Location = new System.Drawing.Point(12, 12);
    this.listBoxFilters.Name = "listBoxFilters";
    this.listBoxFilters.Size = new System.Drawing.Size(200, 180);
    this.listBoxFilters.TabIndex = 0;
    // 
    // FilterLibraryForm
    // 
    this.ClientSize = new System.Drawing.Size(800, 450);
    this.Controls.Add(this.listBoxFilters);
    this.Name = "FilterLibraryForm";
    this.Text = "Filter Library";
    this.ResumeLayout(false);
}
