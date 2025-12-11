namespace FinalProject.Views
{
    partial class FormAddChecklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddChecklist));
            this.pnlBody4 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddChecklist = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlTitle = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAddChecklist = new System.Windows.Forms.Label();
            this.pnlBody4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody2.SuspendLayout();
            this.pnlBody3.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody4
            // 
            this.pnlBody4.Controls.Add(this.pbxLogo);
            this.pnlBody4.Controls.Add(this.pnlBody1);
            this.pnlBody4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody4.FillColor = System.Drawing.Color.White;
            this.pnlBody4.Location = new System.Drawing.Point(0, 0);
            this.pnlBody4.Name = "pnlBody4";
            this.pnlBody4.Size = new System.Drawing.Size(1642, 90);
            this.pnlBody4.TabIndex = 2;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(137, 10);
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
            // pnlBody2
            // 
            this.pnlBody2.AutoScroll = true;
            this.pnlBody2.Controls.Add(this.pnlBody3);
            this.pnlBody2.Controls.Add(this.pnlTitle);
            this.pnlBody2.Controls.Add(this.lblAddChecklist);
            this.pnlBody2.Location = new System.Drawing.Point(0, 86);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1639, 858);
            this.pnlBody2.TabIndex = 8;
            // 
            // pnlBody3
            // 
            this.pnlBody3.BorderColor = System.Drawing.Color.Black;
            this.pnlBody3.BorderThickness = 1;
            this.pnlBody3.Controls.Add(this.cboStatus);
            this.pnlBody3.Controls.Add(this.cmbDepartment);
            this.pnlBody3.Controls.Add(this.btnAddChecklist);
            this.pnlBody3.Controls.Add(this.dtpDueDate);
            this.pnlBody3.Controls.Add(this.lblDueDate);
            this.pnlBody3.Controls.Add(this.lblDepartment);
            this.pnlBody3.Controls.Add(this.lblStatus);
            this.pnlBody3.Controls.Add(this.txtDescription);
            this.pnlBody3.Location = new System.Drawing.Point(37, 141);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1553, 650);
            this.pnlBody3.TabIndex = 11;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Items.AddRange(new object[] {
            "Open",
            "In progress",
            "Complete",
            "Closed"});
            this.cboStatus.Location = new System.Drawing.Point(237, 387);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(284, 36);
            this.cboStatus.TabIndex = 3;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.BackColor = System.Drawing.Color.Transparent;
            this.cmbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDepartment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbDepartment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbDepartment.ItemHeight = 30;
            this.cmbDepartment.Location = new System.Drawing.Point(237, 474);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(284, 36);
            this.cmbDepartment.TabIndex = 4;
            // 
            // btnAddChecklist
            // 
            this.btnAddChecklist.BorderRadius = 7;
            this.btnAddChecklist.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChecklist.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChecklist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddChecklist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddChecklist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAddChecklist.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddChecklist.ForeColor = System.Drawing.Color.White;
            this.btnAddChecklist.Location = new System.Drawing.Point(669, 556);
            this.btnAddChecklist.Name = "btnAddChecklist";
            this.btnAddChecklist.Size = new System.Drawing.Size(150, 40);
            this.btnAddChecklist.TabIndex = 6;
            this.btnAddChecklist.Text = "Add";
            this.btnAddChecklist.Click += new System.EventHandler(this.buttonAddChecklist_Click);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Checked = true;
            this.dtpDueDate.FillColor = System.Drawing.Color.White;
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(237, 560);
            this.dtpDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(284, 36);
            this.dtpDueDate.TabIndex = 5;
            this.dtpDueDate.Value = new System.DateTime(2024, 10, 30, 0, 24, 4, 459);
            // 
            // lblDueDate
            // 
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(48, 569);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
            this.lblDueDate.TabIndex = 10;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblDepartment
            // 
            this.lblDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(48, 487);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(134, 23);
            this.lblDepartment.TabIndex = 7;
            this.lblDepartment.Text = "Assignee";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(48, 400);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(169, 23);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(52, 46);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtDescription.PlaceholderText = "Add description";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(1450, 280);
            this.txtDescription.TabIndex = 1;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Controls.Add(this.txtTitle);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.FillColor = System.Drawing.Color.Transparent;
            this.pnlTitle.Location = new System.Drawing.Point(37, 56);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1553, 70);
            this.pnlTitle.TabIndex = 10;
            // 
            // txtTitle
            // 
            this.txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTitle.DefaultText = "";
            this.txtTitle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTitle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTitle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTitle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTitle.Location = new System.Drawing.Point(100, 10);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PasswordChar = '\0';
            this.txtTitle.PlaceholderText = "";
            this.txtTitle.SelectedText = "";
            this.txtTitle.Size = new System.Drawing.Size(611, 48);
            this.txtTitle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Title";
            // 
            // lblAddChecklist
            // 
            this.lblAddChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddChecklist.Location = new System.Drawing.Point(32, 17);
            this.lblAddChecklist.Name = "lblAddChecklist";
            this.lblAddChecklist.Size = new System.Drawing.Size(423, 33);
            this.lblAddChecklist.TabIndex = 8;
            this.lblAddChecklist.Text = "Add Checklist";
            // 
            // FormAddChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.pnlBody2);
            this.Controls.Add(this.pnlBody4);
            this.MaximizeBox = false;
            this.Name = "FormAddChecklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddChecklist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlBody4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody3.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody4;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2Panel pnlTitle;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddChecklist;
        private System.Windows.Forms.Label lblAddChecklist;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}