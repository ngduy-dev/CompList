using FinalProject.Models;
using System;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormDashboard : Form, ILocalizable
    {
        public FormDashboard()
        {
            InitializeComponent();
            ApplyLanguage();
        }

        public void ApplyLanguage()
        {
            lblCompList.Text = LanguageManager.Translate("welcome_line");
            lblWelcome.Text = LanguageManager.Translate("welcome_message");
        }
    }
}
