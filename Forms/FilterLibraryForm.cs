using System;
using System.Linq;
using System.Windows.Forms;
using ImageEditorApp.Patterns.Strategy;

namespace ImageEditorApp.Forms
{
    public partial class FilterLibraryForm : Form
    {
        public IImageFilter SelectedFilter { get; private set; }

        public FilterLibraryForm()
        {
            InitializeComponent();
            LoadFilters();
        }

        private void LoadFilters()
        {
            var filterType = typeof(IImageFilter);

            var filters = filterType.Assembly.GetTypes()
                .Where(t => filterType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t) as IImageFilter)
                .ToList();

            comboFilters.DataSource = filters;
            comboFilters.DisplayMember = "Name";
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SelectedFilter = comboFilters.SelectedItem as IImageFilter;
            if (SelectedFilter == null)
            {
                MessageBox.Show("Select filter");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
