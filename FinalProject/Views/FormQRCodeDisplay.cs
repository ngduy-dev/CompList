using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormQRCodeDisplay : Form
    {
        public FormQRCodeDisplay(Bitmap qrCodeImage, string checklistID, string checklistTitle)
        {
            InitializeComponent();
            pbxQRDisplay.Image = qrCodeImage;
            pbxQRDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            lblChecklistID.Text = "Checklist ID: " + checklistID.Trim() + " - Title: " + checklistTitle;
        }
    }
}
