using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Signals
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            // A legjobb megközelítés a SystemAware lenne (alapértelmezett), de azzal nem jól skálázza
            // a rajzokat nagy DPI-n.
            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            MainForm_IMO7KC mnWindow = new MainForm_IMO7KC();
            App.Initialize(mnWindow);
            Application.Run(mnWindow);
        }
    }
}
