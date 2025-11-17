using System;
using System.Windows.Forms;

namespace ImageEditorApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize(); // .NET 6 WinForms
            Application.Run(new MainForm());
        }
    }
}
