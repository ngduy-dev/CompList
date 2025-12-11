namespace FinalProject.Views
{
    partial class FormAddDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDepartment));
            this.pnlBody5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlBody4 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpBirthDay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.cmbGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.lblUserID = new System.Windows.Forms.Label();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtDepartmentName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblInfomation = new System.Windows.Forms.Label();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBody5.SuspendLayout();
            this.pnlBody4.SuspendLayout();
            this.pnlBody2.SuspendLayout();
            this.pnlBody3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBody5
            // 
            this.pnlBody5.AutoScroll = true;
            this.pnlBody5.Controls.Add(this.lblUser);
            this.pnlBody5.Controls.Add(this.pnlBody4);
            this.pnlBody5.Controls.Add(this.pnlBody2);
            this.pnlBody5.Controls.Add(this.lblInfomation);
            this.pnlBody5.Location = new System.Drawing.Point(22, 165);
            this.pnlBody5.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody5.Name = "pnlBody5";
            this.pnlBody5.Size = new System.Drawing.Size(1469, 624);
            this.pnlBody5.TabIndex = 16;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(32, 146);
            this.lblUser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(715, 32);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "New Account for this Department Head";
            // 
            // pnlBody4
            // 
            this.pnlBody4.BorderColor = System.Drawing.Color.Black;
            this.pnlBody4.BorderThickness = 1;
            this.pnlBody4.Controls.Add(this.dtpBirthDay);
            this.pnlBody4.Controls.Add(this.lblBirthday);
            this.pnlBody4.Controls.Add(this.cmbGender);
            this.pnlBody4.Controls.Add(this.lblGender);
            this.pnlBody4.Controls.Add(this.txtPhoneNumber);
            this.pnlBody4.Controls.Add(this.lblPhoneNumber);
            this.pnlBody4.Controls.Add(this.txtEmail);
            this.pnlBody4.Controls.Add(this.lblEmail);
            this.pnlBody4.Controls.Add(this.txtFullName);
            this.pnlBody4.Controls.Add(this.txtUserID);
            this.pnlBody4.Controls.Add(this.btnClose);
            this.pnlBody4.Controls.Add(this.lblFullName);
            this.pnlBody4.Controls.Add(this.btnSave);
            this.pnlBody4.Controls.Add(this.lblUserID);
            this.pnlBody4.Location = new System.Drawing.Point(38, 196);
            this.pnlBody4.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody4.Name = "pnlBody4";
            this.pnlBody4.Size = new System.Drawing.Size(1382, 408);
            this.pnlBody4.TabIndex = 11;
            // 
            // dtpBirthDay
            // 
            this.dtpBirthDay.BackColor = System.Drawing.Color.White;
            this.dtpBirthDay.Checked = true;
            this.dtpBirthDay.FillColor = System.Drawing.Color.White;
            this.dtpBirthDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBirthDay.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpBirthDay.Location = new System.Drawing.Point(206, 228);
            this.dtpBirthDay.Margin = new System.Windows.Forms.Padding(2);
            this.dtpBirthDay.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBirthDay.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDay.Name = "dtpBirthDay";
            this.dtpBirthDay.Size = new System.Drawing.Size(378, 48);
            this.dtpBirthDay.TabIndex = 3;
            this.dtpBirthDay.Value = new System.DateTime(2024, 11, 22, 8, 56, 40, 458);
            // 
            // lblBirthday
            // 
            this.lblBirthday.BackColor = System.Drawing.Color.Transparent;
            this.lblBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthday.Location = new System.Drawing.Point(25, 235);
            this.lblBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(100, 22);
            this.lblBirthday.TabIndex = 32;
            this.lblBirthday.Text = "Birthday";
            // 
            // cmbGender
            // 
            this.cmbGender.BackColor = System.Drawing.Color.Transparent;
            this.cmbGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbGender.ItemHeight = 30;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(805, 229);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(378, 36);
            this.cmbGender.TabIndex = 6;
            // 
            // lblGender
            // 
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(662, 232);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(100, 22);
            this.lblGender.TabIndex = 30;
            this.lblGender.Text = "Gender";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneNumber.DefaultText = "";
            this.txtPhoneNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhoneNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhoneNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhoneNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneNumber.Location = new System.Drawing.Point(206, 130);
            this.txtPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PasswordChar = '\0';
            this.txtPhoneNumber.PlaceholderText = "";
            this.txtPhoneNumber.SelectedText = "";
            this.txtPhoneNumber.Size = new System.Drawing.Size(378, 48);
            this.txtPhoneNumber.TabIndex = 2;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(25, 140);
            this.lblPhoneNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(158, 22);
            this.lblPhoneNumber.TabIndex = 16;
            this.lblPhoneNumber.Text = "Number phone";
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
            this.txtEmail.Location = new System.Drawing.Point(805, 32);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(378, 48);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(662, 45);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 22);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email";
            // 
            // txtFullName
            // 
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Location = new System.Drawing.Point(805, 131);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PasswordChar = '\0';
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(378, 48);
            this.txtFullName.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserID.DefaultText = "";
            this.txtUserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Location = new System.Drawing.Point(206, 32);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '\0';
            this.txtUserID.PlaceholderText = "";
            this.txtUserID.ReadOnly = true;
            this.txtUserID.SelectedText = "";
            this.txtUserID.Size = new System.Drawing.Size(378, 48);
            this.txtUserID.TabIndex = 1;
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
            this.btnClose.Location = new System.Drawing.Point(832, 336);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(662, 139);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 22);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "FullName";
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
            this.btnSave.Location = new System.Drawing.Point(1032, 336);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblUserID
            // 
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(25, 45);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(182, 22);
            this.lblUserID.TabIndex = 6;
            this.lblUserID.Text = "UserID";
            // 
            // pnlBody2
            // 
            this.pnlBody2.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody2.Controls.Add(this.txtDepartmentName);
            this.pnlBody2.Controls.Add(this.lblEmployeeName);
            this.pnlBody2.FillColor = System.Drawing.Color.Transparent;
            this.pnlBody2.Location = new System.Drawing.Point(38, 56);
            this.pnlBody2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1382, 70);
            this.pnlBody2.TabIndex = 10;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartmentName.DefaultText = "";
            this.txtDepartmentName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDepartmentName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDepartmentName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDepartmentName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDepartmentName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDepartmentName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDepartmentName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDepartmentName.Location = new System.Drawing.Point(214, 12);
            this.txtDepartmentName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.PasswordChar = '\0';
            this.txtDepartmentName.PlaceholderText = "";
            this.txtDepartmentName.SelectedText = "";
            this.txtDepartmentName.Size = new System.Drawing.Size(370, 48);
            this.txtDepartmentName.TabIndex = 0;
            this.txtDepartmentName.TextChanged += new System.EventHandler(this.txtDepartmentName_TextChanged);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(25, 25);
            this.lblEmployeeName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(224, 22);
            this.lblEmployeeName.TabIndex = 5;
            this.lblEmployeeName.Text = "Department Name";
            // 
            // lblInfomation
            // 
            this.lblInfomation.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfomation.Location = new System.Drawing.Point(32, 18);
            this.lblInfomation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfomation.Name = "lblInfomation";
            this.lblInfomation.Size = new System.Drawing.Size(715, 32);
            this.lblInfomation.TabIndex = 8;
            this.lblInfomation.Text = "New Department (Contractor)";
            // 
            // pnlBody3
            // 
            this.pnlBody3.Controls.Add(this.pbxLogo);
            this.pnlBody3.Controls.Add(this.pnlBody1);
            this.pnlBody3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody3.FillColor = System.Drawing.Color.White;
            this.pnlBody3.Location = new System.Drawing.Point(0, 0);
            this.pnlBody3.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1525, 90);
            this.pnlBody3.TabIndex = 15;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(138, 10);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(2);
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
            this.pnlBody1.Location = new System.Drawing.Point(38, 10);
            this.pnlBody1.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody1.Name = "pnlBody1";
            this.pnlBody1.Size = new System.Drawing.Size(72, 70);
            this.pnlBody1.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.pbxIcon.Image = global::FinalProject.Properties.Resources.icons8_hard_drive_32;
            this.pbxIcon.ImageRotate = 0F;
            this.pbxIcon.Location = new System.Drawing.Point(10, 10);
            this.pbxIcon.Margin = new System.Windows.Forms.Padding(2);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(50, 50);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 2;
            this.pbxIcon.TabStop = false;
            // 
            // FormAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1525, 841);
            this.Controls.Add(this.pnlBody5);
            this.Controls.Add(this.pnlBody3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormAddDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDepartment";
            this.pnlBody5.ResumeLayout(false);
            this.pnlBody4.ResumeLayout(false);
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody5;
        private Guna.UI2.WinForms.Guna2Panel pnlBody4;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label lblUserID;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblInfomation;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private System.Windows.Forms.Label lblUser;
        private Guna.UI2.WinForms.Guna2TextBox txtUserID;
        private Guna.UI2.WinForms.Guna2TextBox txtDepartmentName;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblFullName;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirthDay;
        private System.Windows.Forms.Label lblBirthday;
        private Guna.UI2.WinForms.Guna2ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}