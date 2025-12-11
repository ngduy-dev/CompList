namespace FinalProject.Views
{
    partial class FormChecklist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChecklist));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnInprogress = new Guna.UI2.WinForms.Guna2Button();
            this.btnComplete = new Guna.UI2.WinForms.Guna2Button();
            this.btnOpen = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblChecklists = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnInfomation = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnQRCode = new System.Windows.Forms.Button();
            this.dgvChecklist = new System.Windows.Forms.DataGridView();
            this.btnClosed = new Guna.UI2.WinForms.Guna2Button();
            this.lblDue = new System.Windows.Forms.Label();
            this.dtpDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.dtpCreateDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnAllTime = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pnlBody2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).BeginInit();
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
            this.pnlBody2.TabIndex = 3;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(139, 10);
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
            // btnInprogress
            // 
            this.btnInprogress.BackColor = System.Drawing.Color.Transparent;
            this.btnInprogress.BorderColor = System.Drawing.Color.Transparent;
            this.btnInprogress.BorderRadius = 9;
            this.btnInprogress.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInprogress.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInprogress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInprogress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInprogress.FillColor = System.Drawing.Color.Transparent;
            this.btnInprogress.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInprogress.ForeColor = System.Drawing.Color.Black;
            this.btnInprogress.Location = new System.Drawing.Point(370, 193);
            this.btnInprogress.Name = "btnInprogress";
            this.btnInprogress.Size = new System.Drawing.Size(147, 21);
            this.btnInprogress.TabIndex = 2;
            this.btnInprogress.Text = "In progress";
            this.btnInprogress.Click += new System.EventHandler(this.btnInprogress_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnComplete.BorderColor = System.Drawing.Color.Transparent;
            this.btnComplete.BorderRadius = 9;
            this.btnComplete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnComplete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnComplete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnComplete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnComplete.FillColor = System.Drawing.Color.Transparent;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.ForeColor = System.Drawing.Color.Black;
            this.btnComplete.Location = new System.Drawing.Point(526, 193);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(137, 21);
            this.btnComplete.TabIndex = 3;
            this.btnComplete.Text = "Complete";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.BorderColor = System.Drawing.Color.Transparent;
            this.btnOpen.BorderRadius = 9;
            this.btnOpen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOpen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOpen.FillColor = System.Drawing.Color.Transparent;
            this.btnOpen.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.Black;
            this.btnOpen.Location = new System.Drawing.Point(244, 193);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(108, 21);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderColor = System.Drawing.Color.Transparent;
            this.btnAll.BorderRadius = 9;
            this.btnAll.CheckedState.FillColor = System.Drawing.Color.Transparent;
            this.btnAll.CheckedState.ForeColor = System.Drawing.Color.Black;
            this.btnAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAll.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(139, 193);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(87, 21);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(34, 195);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 20);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status:";
            // 
            // lblChecklists
            // 
            this.lblChecklists.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklists.Location = new System.Drawing.Point(32, 132);
            this.lblChecklists.Name = "lblChecklists";
            this.lblChecklists.Size = new System.Drawing.Size(194, 33);
            this.lblChecklists.TabIndex = 12;
            this.lblChecklists.Text = "Checklists";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(35, 237);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(184, 23);
            this.lblDepartment.TabIndex = 14;
            this.lblDepartment.Text = "Department";
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
            this.cmbDepartment.Location = new System.Drawing.Point(36, 272);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(245, 36);
            this.cmbDepartment.TabIndex = 5;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox_department_SelectedIndexChanged);
            // 
            // btnInfomation
            // 
            this.btnInfomation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnInfomation.ForeColor = System.Drawing.Color.White;
            this.btnInfomation.Location = new System.Drawing.Point(40, 379);
            this.btnInfomation.Name = "btnInfomation";
            this.btnInfomation.Size = new System.Drawing.Size(145, 46);
            this.btnInfomation.TabIndex = 9;
            this.btnInfomation.Text = "Detail";
            this.btnInfomation.UseVisualStyleBackColor = false;
            this.btnInfomation.Click += new System.EventHandler(this.btnInfomation_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(541, 379);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 46);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(372, 379);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 46);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.buttonUpdate_Click_1);
            // 
            // btnQRCode
            // 
            this.btnQRCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnQRCode.ForeColor = System.Drawing.Color.White;
            this.btnQRCode.Location = new System.Drawing.Point(711, 379);
            this.btnQRCode.Name = "btnQRCode";
            this.btnQRCode.Size = new System.Drawing.Size(145, 46);
            this.btnQRCode.TabIndex = 13;
            this.btnQRCode.Text = "QR Code";
            this.btnQRCode.UseVisualStyleBackColor = false;
            this.btnQRCode.Click += new System.EventHandler(this.btnQRCode_Click);
            // 
            // dgvChecklist
            // 
            this.dgvChecklist.AllowUserToAddRows = false;
            this.dgvChecklist.AllowUserToDeleteRows = false;
            this.dgvChecklist.AllowUserToOrderColumns = true;
            this.dgvChecklist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecklist.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvChecklist.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChecklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChecklist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChecklist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecklist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChecklist.EnableHeadersVisualStyles = false;
            this.dgvChecklist.GridColor = System.Drawing.Color.Black;
            this.dgvChecklist.Location = new System.Drawing.Point(38, 457);
            this.dgvChecklist.MultiSelect = false;
            this.dgvChecklist.Name = "dgvChecklist";
            this.dgvChecklist.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklist.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChecklist.RowHeadersVisible = false;
            this.dgvChecklist.RowHeadersWidth = 51;
            this.dgvChecklist.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvChecklist.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChecklist.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvChecklist.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvChecklist.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklist.RowTemplate.Height = 24;
            this.dgvChecklist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecklist.Size = new System.Drawing.Size(1537, 400);
            this.dgvChecklist.TabIndex = 69;
            // 
            // btnClosed
            // 
            this.btnClosed.BackColor = System.Drawing.Color.Transparent;
            this.btnClosed.BorderColor = System.Drawing.Color.Transparent;
            this.btnClosed.BorderRadius = 9;
            this.btnClosed.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClosed.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClosed.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClosed.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClosed.FillColor = System.Drawing.Color.Transparent;
            this.btnClosed.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnClosed.ForeColor = System.Drawing.Color.Black;
            this.btnClosed.Location = new System.Drawing.Point(669, 193);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(103, 21);
            this.btnClosed.TabIndex = 4;
            this.btnClosed.Text = "Closed";
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
            // 
            // lblDue
            // 
            this.lblDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(648, 237);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(184, 23);
            this.lblDue.TabIndex = 70;
            this.lblDue.Text = "Due date";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.BackColor = System.Drawing.Color.White;
            this.dtpDueDate.Checked = true;
            this.dtpDueDate.FillColor = System.Drawing.Color.White;
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDueDate.Location = new System.Drawing.Point(652, 272);
            this.dtpDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(257, 36);
            this.dtpDueDate.TabIndex = 71;
            this.dtpDueDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            this.dtpDueDate.ValueChanged += new System.EventHandler(this.dtpDueDate_ValueChanged);
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(354, 237);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(184, 23);
            this.lblCreateDate.TabIndex = 72;
            this.lblCreateDate.Text = "Create Date";
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.BackColor = System.Drawing.Color.White;
            this.dtpCreateDate.Checked = true;
            this.dtpCreateDate.FillColor = System.Drawing.Color.White;
            this.dtpCreateDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpCreateDate.Location = new System.Drawing.Point(358, 272);
            this.dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.Size = new System.Drawing.Size(267, 36);
            this.dtpCreateDate.TabIndex = 73;
            this.dtpCreateDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            this.dtpCreateDate.ValueChanged += new System.EventHandler(this.dtpCreateDate_ValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(159, 321);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(407, 48);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(47, 330);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(127, 23);
            this.lblSearch.TabIndex = 75;
            this.lblSearch.Text = "Search";
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(207, 379);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(145, 46);
            this.btnReload.TabIndex = 10;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnAllTime
            // 
            this.btnAllTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAllTime.ForeColor = System.Drawing.Color.White;
            this.btnAllTime.Location = new System.Drawing.Point(941, 272);
            this.btnAllTime.Name = "btnAllTime";
            this.btnAllTime.Size = new System.Drawing.Size(134, 36);
            this.btnAllTime.TabIndex = 6;
            this.btnAllTime.Text = "All time";
            this.btnAllTime.UseVisualStyleBackColor = false;
            this.btnAllTime.Click += new System.EventHandler(this.btnAllTime_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnExportAll.ForeColor = System.Drawing.Color.White;
            this.btnExportAll.Location = new System.Drawing.Point(873, 379);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(145, 46);
            this.btnExportAll.TabIndex = 14;
            this.btnExportAll.Text = "Export All";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(1099, 272);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(134, 36);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // FormChecklist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnExportAll);
            this.Controls.Add(this.btnAllTime);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.dgvChecklist);
            this.Controls.Add(this.btnQRCode);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnInfomation);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.lblChecklists);
            this.Controls.Add(this.btnInprogress);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlBody2);
            this.MaximizeBox = false;
            this.Name = "FormChecklist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checklist";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Checklist_Load);
            this.pnlBody2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2Button btnInprogress;
        private Guna.UI2.WinForms.Guna2Button btnComplete;
        private Guna.UI2.WinForms.Guna2Button btnOpen;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblChecklists;
        private System.Windows.Forms.Label lblDepartment;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private System.Windows.Forms.Button btnInfomation;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnQRCode;
        private System.Windows.Forms.DataGridView dgvChecklist;
        private Guna.UI2.WinForms.Guna2Button btnClosed;
        private System.Windows.Forms.Label lblDue;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDueDate;
        private System.Windows.Forms.Label lblCreateDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCreateDate;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnAllTime;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Button btnFilter;
    }
}