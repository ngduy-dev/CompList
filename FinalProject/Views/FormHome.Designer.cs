namespace FinalProject.Views
{
    partial class FormHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSendReminder = new Guna.UI2.WinForms.Guna2Button();
            this.lblRecent = new System.Windows.Forms.Label();
            this.dgvRecentUpdate = new System.Windows.Forms.DataGridView();
            this.pnlBody2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody2
            // 
            this.pnlBody2.Controls.Add(this.pbxLogo);
            this.pnlBody2.Controls.Add(this.pnlBody1);
            this.pnlBody2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody2.FillColor = System.Drawing.Color.White;
            this.pnlBody2.Location = new System.Drawing.Point(0, 0);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1642, 90);
            this.pnlBody2.TabIndex = 1;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(136, 10);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(184, 70);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 4;
            this.pbxLogo.TabStop = false;
            this.pbxLogo.WaitOnLoad = true;
            // 
            // pnlBody1
            // 
            this.pnlBody1.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody1.BorderRadius = 10;
            this.pnlBody1.Controls.Add(this.pbxIcon);
            this.pnlBody1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pnlBody1.Location = new System.Drawing.Point(37, 10);
            this.pnlBody1.Name = "pnlBody1";
            this.pnlBody1.Size = new System.Drawing.Size(73, 70);
            this.pnlBody1.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pbxIcon.Image = global::FinalProject.Properties.Resources.icons8_hard_drive_32;
            this.pbxIcon.ImageRotate = 0F;
            this.pbxIcon.Location = new System.Drawing.Point(10, 10);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(50, 50);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 2;
            this.pbxIcon.TabStop = false;
            // 
            // pnlBody3
            // 
            this.pnlBody3.Controls.Add(this.btnSendReminder);
            this.pnlBody3.Controls.Add(this.lblRecent);
            this.pnlBody3.Location = new System.Drawing.Point(37, 123);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1517, 66);
            this.pnlBody3.TabIndex = 40;
            // 
            // btnSendReminder
            // 
            this.btnSendReminder.BorderRadius = 7;
            this.btnSendReminder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendReminder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendReminder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendReminder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendReminder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnSendReminder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSendReminder.ForeColor = System.Drawing.Color.White;
            this.btnSendReminder.Location = new System.Drawing.Point(1317, 16);
            this.btnSendReminder.Name = "btnSendReminder";
            this.btnSendReminder.Size = new System.Drawing.Size(178, 35);
            this.btnSendReminder.TabIndex = 21;
            this.btnSendReminder.Text = "Send reminder";
            this.btnSendReminder.Click += new System.EventHandler(this.btnSendReminder_Click);
            // 
            // lblRecent
            // 
            this.lblRecent.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecent.Location = new System.Drawing.Point(3, 9);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(221, 45);
            this.lblRecent.TabIndex = 20;
            this.lblRecent.Text = "Recent Response";
            this.lblRecent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvRecentUpdate
            // 
            this.dgvRecentUpdate.AllowUserToAddRows = false;
            this.dgvRecentUpdate.AllowUserToDeleteRows = false;
            this.dgvRecentUpdate.AllowUserToOrderColumns = true;
            this.dgvRecentUpdate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentUpdate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRecentUpdate.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvRecentUpdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentUpdate.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentUpdate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecentUpdate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentUpdate.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvRecentUpdate.EnableHeadersVisualStyles = false;
            this.dgvRecentUpdate.GridColor = System.Drawing.Color.Black;
            this.dgvRecentUpdate.Location = new System.Drawing.Point(37, 221);
            this.dgvRecentUpdate.MultiSelect = false;
            this.dgvRecentUpdate.Name = "dgvRecentUpdate";
            this.dgvRecentUpdate.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentUpdate.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecentUpdate.RowHeadersVisible = false;
            this.dgvRecentUpdate.RowHeadersWidth = 51;
            this.dgvRecentUpdate.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRecentUpdate.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvRecentUpdate.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvRecentUpdate.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRecentUpdate.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecentUpdate.RowTemplate.Height = 24;
            this.dgvRecentUpdate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentUpdate.Size = new System.Drawing.Size(1517, 563);
            this.dgvRecentUpdate.TabIndex = 70;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.dgvRecentUpdate);
            this.Controls.Add(this.pnlBody3);
            this.Controls.Add(this.pnlBody2);
            this.MaximizeBox = false;
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormHome_Load_1);
            this.pnlBody2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.DataGridView dgvRecentUpdate;
        private Guna.UI2.WinForms.Guna2Button btnSendReminder;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}