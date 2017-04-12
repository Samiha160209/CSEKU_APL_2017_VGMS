using System;
using System.Windows.Forms;
using VideoGallery.WinApp.Documents.CustomerManager;
//using VideoGallery.WinApp.Documents.CustomerManager;
using VideoGallery.WinApp.Documents.ProductManager;
using VideoGallery.WinApp.Documents.SellManager;

namespace VideoGallery.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
