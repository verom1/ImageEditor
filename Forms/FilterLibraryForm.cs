public partial class FilterLibraryForm : Form
{
    public FilterLibraryForm()
    {
        InitializeComponent();
    }

    private void LoadFilters()
    {
        listBoxFilters.Items.Clear();
        listBoxFilters.Items.Add("Black & White");
        listBoxFilters.Items.Add("Sepia");
        listBoxFilters.Items.Add("Brightness");
    }
}
