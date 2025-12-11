namespace FinalProject.Views
{
    partial class FormQRCodeDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblChecklistID = new System.Windows.Forms.Label();
            this.pbxQRDisplay = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQRDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // lblChecklistID
            // 
            this.lblChecklistID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistID.Location = new System.Drawing.Point(75, 717);
            this.lblChecklistID.Name = "lblChecklistID";
            this.lblChecklistID.Size = new System.Drawing.Size(837, 50);
            this.lblChecklistID.TabIndex = 1;
            this.lblChecklistID.Text = "label1";
            this.lblChecklistID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxQRDisplay
            // 
            this.pbxQRDisplay.ImageRotate = 0F;
            this.pbxQRDisplay.Location = new System.Drawing.Point(75, 25);
            this.pbxQRDisplay.Name = "pbxQRDisplay";
            this.pbxQRDisplay.Size = new System.Drawing.Size(837, 681);
            this.pbxQRDisplay.TabIndex = 0;
            this.pbxQRDisplay.TabStop = false;
            // 
            // FormQRCodeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 776);
            this.Controls.Add(this.lblChecklistID);
            this.Controls.Add(this.pbxQRDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormQRCodeDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QRCodeDisplayForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbxQRDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbxQRDisplay;
        private System.Windows.Forms.Label lblChecklistID;
    }
}