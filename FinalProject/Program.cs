using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.Views;

namespace FinalProject
{
    internal static class Program
    {
        public static string connectionString = "Data Source=MSIBRAVO15\\QUOCDUY;Initial Catalog=CHECKLIST;Integrated Security=True;Encrypt=True";
        //public static string connectionString = "Data Source=DESKTOP-88U4TGL;Initial Catalog=CHECKLIST;Integrated Security=True;";
        //public static string connectionString = "Data Source=DONGDUY215\\SQL2019;Initial Catalog=CHECKLIST;User ID=sa;Password=dongduy215;Encrypt=True;TrustServerCertificate=True";
        //public static string connectionString = "Data Source=DESKTOP-0TUPAG2\\QUANGTRUNG;Initial Catalog=CHECKLIST;User ID=sa;Password=1easygame;Encrypt=True;TrustServerCertificate=True";




        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string language = Properties.Settings.Default.Language ?? "en";
            LanguageManager.LoadLanguage(language);
            Application.Run(new FormLogin());
        }

    }
}
