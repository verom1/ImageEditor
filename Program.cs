using System;
using System.Windows.Forms;
using ImageEditorApp.Data;
using ImageEditorApp.Repositories;
using System;
using System.Windows.Forms;
using ImageEditorApp.Forms;

namespace ImageEditorApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EditForm());
        }
    }
}
