namespace FinalProject.Views
{
    partial class FormEmployeeInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEmployeeInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtghecklistItem = new System.Windows.Forms.DataGridView();
            this.cbxIsActive = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtNumberPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblNumberPhone = new System.Windows.Forms.Label();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblInfomation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            this.pnlBody2.SuspendLayout();
            this.pnlBody4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtghecklistItem)).BeginInit();
            this.pnlBody3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pbxIcon.Image = global::FinalProject.Properties.Resources.icons8_hard_drive_32;
            this.pbxIcon.ImageRotate = 0F;
            this.pbxIcon.Location = new System.Drawing.Point(11, 10);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(51, 50);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 2;
            this.pbxIcon.TabStop = false;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.pbxLogo);
            this.pnlLogo.Controls.Add(this.pnlBody1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.FillColor = System.Drawing.Color.White;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(1381, 90);
            this.pnlLogo.TabIndex = 11;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(137, 10);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pnlBody1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody1.Name = "pnlBody1";
            this.pnlBody1.Size = new System.Drawing.Size(73, 70);
            this.pnlBody1.TabIndex = 1;
            // 
            // pnlBody2
            // 
            this.pnlBody2.AutoScroll = true;
            this.pnlBody2.Controls.Add(this.pnlBody4);
            this.pnlBody2.Controls.Add(this.pnlBody3);
            this.pnlBody2.Controls.Add(this.lblInfomation);
            this.pnlBody2.Location = new System.Drawing.Point(0, 85);
            this.pnlBody2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1372, 705);
            this.pnlBody2.TabIndex = 12;
            // 
            // pnlBody4
            // 
            this.pnlBody4.BorderColor = System.Drawing.Color.Black;
            this.pnlBody4.BorderThickness = 1;
            this.pnlBody4.Controls.Add(this.dtghecklistItem);
            this.pnlBody4.Controls.Add(this.cbxIsActive);
            this.pnlBody4.Controls.Add(this.lblIsActive);
            this.pnlBody4.Controls.Add(this.txtEmail);
            this.pnlBody4.Controls.Add(this.cmbDepartment);
            this.pnlBody4.Controls.Add(this.txtNumberPhone);
            this.pnlBody4.Controls.Add(this.btnClose);
            this.pnlBody4.Controls.Add(this.btnSave);
            this.pnlBody4.Controls.Add(this.lblEmail);
            this.pnlBody4.Controls.Add(this.lblDepartment);
            this.pnlBody4.Controls.Add(this.lblNumberPhone);
            this.pnlBody4.Location = new System.Drawing.Point(37, 142);
            this.pnlBody4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody4.Name = "pnlBody4";
            this.pnlBody4.Size = new System.Drawing.Size(1287, 534);
            this.pnlBody4.TabIndex = 11;
            // 
            // dtghecklistItem
            // 
            this.dtghecklistItem.AllowUserToAddRows = false;
            this.dtghecklistItem.AllowUserToDeleteRows = false;
            this.dtghecklistItem.AllowUserToOrderColumns = true;
            this.dtghecklistItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtghecklistItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtghecklistItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtghecklistItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtghecklistItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtghecklistItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtghecklistItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtghecklistItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtghecklistItem.EnableHeadersVisualStyles = false;
            this.dtghecklistItem.GridColor = System.Drawing.Color.Black;
            this.dtghecklistItem.Location = new System.Drawing.Point(29, 207);
            this.dtghecklistItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtghecklistItem.MultiSelect = false;
            this.dtghecklistItem.Name = "dtghecklistItem";
            this.dtghecklistItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtghecklistItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtghecklistItem.RowHeadersVisible = false;
            this.dtghecklistItem.RowHeadersWidth = 51;
            this.dtghecklistItem.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtghecklistItem.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dtghecklistItem.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dtghecklistItem.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtghecklistItem.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtghecklistItem.RowTemplate.Height = 24;
            this.dtghecklistItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtghecklistItem.Size = new System.Drawing.Size(1201, 187);
            this.dtghecklistItem.TabIndex = 69;
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.BackColor = System.Drawing.Color.Transparent;
            this.cbxIsActive.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIsActive.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxIsActive.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbxIsActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxIsActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbxIsActive.ItemHeight = 30;
            this.cbxIsActive.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cbxIsActive.Location = new System.Drawing.Point(852, 38);
            this.cbxIsActive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.Size = new System.Drawing.Size(377, 36);
            this.cbxIsActive.TabIndex = 3;
            // 
            // lblIsActive
            // 
            this.lblIsActive.BackColor = System.Drawing.Color.Transparent;
            this.lblIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.Location = new System.Drawing.Point(663, 46);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(145, 23);
            this.lblIsActive.TabIndex = 23;
            this.lblIsActive.Text = "Is Active";
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(852, 144);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(379, 36);
            this.txtEmail.TabIndex = 4;
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
            this.cmbDepartment.Location = new System.Drawing.Point(213, 144);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(377, 36);
            this.cmbDepartment.TabIndex = 2;
            // 
            // txtNumberPhone
            // 
            this.txtNumberPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumberPhone.DefaultText = "";
            this.txtNumberPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumberPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumberPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumberPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumberPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumberPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumberPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumberPhone.Location = new System.Drawing.Point(213, 38);
            this.txtNumberPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumberPhone.Name = "txtNumberPhone";
            this.txtNumberPhone.PasswordChar = '\0';
            this.txtNumberPhone.PlaceholderText = "";
            this.txtNumberPhone.SelectedText = "";
            this.txtNumberPhone.Size = new System.Drawing.Size(379, 36);
            this.txtNumberPhone.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 7;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(852, 439);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 39);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 7;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1080, 439);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 39);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(663, 151);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 23);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "Email";
            // 
            // lblDepartment
            // 
            this.lblDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(25, 151);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(157, 23);
            this.lblDepartment.TabIndex = 7;
            this.lblDepartment.Text = "Department";
            // 
            // lblNumberPhone
            // 
            this.lblNumberPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblNumberPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberPhone.Location = new System.Drawing.Point(25, 46);
            this.lblNumberPhone.Name = "lblNumberPhone";
            this.lblNumberPhone.Size = new System.Drawing.Size(183, 23);
            this.lblNumberPhone.TabIndex = 6;
            this.lblNumberPhone.Text = "Number Phone";
            // 
            // pnlBody3
            // 
            this.pnlBody3.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody3.Controls.Add(this.txtName);
            this.pnlBody3.Controls.Add(this.lblEmployeeName);
            this.pnlBody3.FillColor = System.Drawing.Color.Transparent;
            this.pnlBody3.Location = new System.Drawing.Point(37, 57);
            this.pnlBody3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1287, 70);
            this.pnlBody3.TabIndex = 10;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(213, 11);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(645, 48);
            this.txtName.TabIndex = 0;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(25, 23);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(220, 23);
            this.lblEmployeeName.TabIndex = 5;
            this.lblEmployeeName.Text = "Employee Name";
            // 
            // lblInfomation
            // 
            this.lblInfomation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfomation.Location = new System.Drawing.Point(32, 17);
            this.lblInfomation.Name = "lblInfomation";
            this.lblInfomation.Size = new System.Drawing.Size(963, 33);
            this.lblInfomation.TabIndex = 8;
            this.lblInfomation.Text = "Infomation of ";
            // 
            // FormEmployeeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 830);
            this.Controls.Add(this.pnlLogo);
            this.Controls.Add(this.pnlBody2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormEmployeeInfo";
            this.Text = "EmployeeInfo";
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtghecklistItem)).EndInit();
            this.pnlBody3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlLogo;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2Panel pnlBody4;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblNumberPhone;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private System.Windows.Forms.Label lblEmployeeName;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblInfomation;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2TextBox txtNumberPhone;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblIsActive;
        private Guna.UI2.WinForms.Guna2ComboBox cbxIsActive;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private System.Windows.Forms.DataGridView dtghecklistItem;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}