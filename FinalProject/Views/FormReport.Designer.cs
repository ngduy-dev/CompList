namespace FinalProject.Views
{
    partial class FormReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvChecklist = new System.Windows.Forms.DataGridView();
            this.lblChecklistComplete = new System.Windows.Forms.Label();
            this.prbChecklist = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblHyphen = new System.Windows.Forms.Label();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAllTime = new Guna.UI2.WinForms.Guna2Button();
            this.btnClosed = new Guna.UI2.WinForms.Guna2Button();
            this.btnInprogress = new Guna.UI2.WinForms.Guna2Button();
            this.btnComplete = new Guna.UI2.WinForms.Guna2Button();
            this.btnOpen = new Guna.UI2.WinForms.Guna2Button();
            this.btnAll = new Guna.UI2.WinForms.Guna2Button();
            this.lblStauts = new System.Windows.Forms.Label();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.BorderRadius = 6;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(172)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1320, 25);
            this.btnExport.Margin = new System.Windows.Forms.Padding(2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(200, 50);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export PDF";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.cmbDepartment.Location = new System.Drawing.Point(216, 271);
            this.cmbDepartment.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(245, 36);
            this.cmbDepartment.TabIndex = 0;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(34, 278);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(148, 22);
            this.lblDepartment.TabIndex = 26;
            this.lblDepartment.Text = "Department:";
            // 
            // lblReport
            // 
            this.lblReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(32, 25);
            this.lblReport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReport.Name = "lblReport";
            this.lblReport.Size = new System.Drawing.Size(194, 32);
            this.lblReport.TabIndex = 24;
            this.lblReport.Text = "Report";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody.Controls.Add(this.dgvChecklist);
            this.pnlBody.Controls.Add(this.lblChecklistComplete);
            this.pnlBody.Controls.Add(this.prbChecklist);
            this.pnlBody.Location = new System.Drawing.Point(38, 372);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1552, 559);
            this.pnlBody.TabIndex = 49;
            // 
            // dgvChecklist
            // 
            this.dgvChecklist.AllowUserToAddRows = false;
            this.dgvChecklist.AllowUserToDeleteRows = false;
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
            this.dgvChecklist.EnableHeadersVisualStyles = false;
            this.dgvChecklist.GridColor = System.Drawing.Color.Black;
            this.dgvChecklist.Location = new System.Drawing.Point(2, 12);
            this.dgvChecklist.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChecklist.MultiSelect = false;
            this.dgvChecklist.Name = "dgvChecklist";
            this.dgvChecklist.ReadOnly = true;
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
            this.dgvChecklist.Size = new System.Drawing.Size(1084, 524);
            this.dgvChecklist.TabIndex = 31;
            // 
            // lblChecklistComplete
            // 
            this.lblChecklistComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistComplete.Location = new System.Drawing.Point(1249, 408);
            this.lblChecklistComplete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChecklistComplete.Name = "lblChecklistComplete";
            this.lblChecklistComplete.Size = new System.Drawing.Size(198, 22);
            this.lblChecklistComplete.TabIndex = 30;
            // 
            // prbChecklist
            // 
            this.prbChecklist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.prbChecklist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.prbChecklist.ForeColor = System.Drawing.Color.White;
            this.prbChecklist.Location = new System.Drawing.Point(1205, 86);
            this.prbChecklist.Margin = new System.Windows.Forms.Padding(2);
            this.prbChecklist.Minimum = 0;
            this.prbChecklist.Name = "prbChecklist";
            this.prbChecklist.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.prbChecklist.Size = new System.Drawing.Size(278, 278);
            this.prbChecklist.TabIndex = 0;
            this.prbChecklist.Text = "guna2CircleProgressBar1";
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(592, 278);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(76, 22);
            this.lblFilter.TabIndex = 63;
            this.lblFilter.Text = "Filter:";
            // 
            // lblHyphen
            // 
            this.lblHyphen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHyphen.Location = new System.Drawing.Point(991, 271);
            this.lblHyphen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHyphen.Name = "lblHyphen";
            this.lblHyphen.Size = new System.Drawing.Size(22, 22);
            this.lblHyphen.TabIndex = 62;
            this.lblHyphen.Text = "-";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BackColor = System.Drawing.Color.White;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(1031, 271);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(288, 36);
            this.dtpEndDate.TabIndex = 61;
            this.dtpEndDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BackColor = System.Drawing.Color.White;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(685, 271);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(288, 36);
            this.dtpStartDate.TabIndex = 60;
            this.dtpStartDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            // 
            // btnAllTime
            // 
            this.btnAllTime.BorderRadius = 6;
            this.btnAllTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAllTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAllTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAllTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAllTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(60)))), ((int)(((byte)(172)))));
            this.btnAllTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAllTime.ForeColor = System.Drawing.Color.White;
            this.btnAllTime.Location = new System.Drawing.Point(1348, 270);
            this.btnAllTime.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllTime.Name = "btnAllTime";
            this.btnAllTime.Size = new System.Drawing.Size(172, 38);
            this.btnAllTime.TabIndex = 1;
            this.btnAllTime.Text = "All time";
            this.btnAllTime.Click += new System.EventHandler(this.btnAllTime_Click);
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
            this.btnClosed.Location = new System.Drawing.Point(674, 208);
            this.btnClosed.Margin = new System.Windows.Forms.Padding(2);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(102, 21);
            this.btnClosed.TabIndex = 70;
            this.btnClosed.Tag = "Closed";
            this.btnClosed.Text = "Closed";
            this.btnClosed.Click += new System.EventHandler(this.btnClosed_Click);
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
            this.btnInprogress.Location = new System.Drawing.Point(362, 208);
            this.btnInprogress.Margin = new System.Windows.Forms.Padding(2);
            this.btnInprogress.Name = "btnInprogress";
            this.btnInprogress.Size = new System.Drawing.Size(162, 21);
            this.btnInprogress.TabIndex = 69;
            this.btnInprogress.Tag = "In progress";
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
            this.btnComplete.Location = new System.Drawing.Point(531, 208);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(138, 21);
            this.btnComplete.TabIndex = 68;
            this.btnComplete.Tag = "Complete";
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
            this.btnOpen.Location = new System.Drawing.Point(244, 208);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(105, 21);
            this.btnOpen.TabIndex = 67;
            this.btnOpen.Tag = "Open";
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
            this.btnAll.Location = new System.Drawing.Point(141, 208);
            this.btnAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(98, 21);
            this.btnAll.TabIndex = 66;
            this.btnAll.Tag = "All";
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // lblStauts
            // 
            this.lblStauts.AutoSize = true;
            this.lblStauts.BackColor = System.Drawing.Color.Transparent;
            this.lblStauts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStauts.Location = new System.Drawing.Point(34, 209);
            this.lblStauts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStauts.Name = "lblStauts";
            this.lblStauts.Size = new System.Drawing.Size(69, 20);
            this.lblStauts.TabIndex = 65;
            this.lblStauts.Text = "Status:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BorderRadius = 6;
            this.btnExportExcel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportExcel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportExcel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportExcel.FillColor = System.Drawing.Color.Green;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(1070, 25);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(200, 50);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnClosed);
            this.Controls.Add(this.btnInprogress);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.lblStauts);
            this.Controls.Add(this.btnAllTime);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblHyphen);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblReport);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Report_Load);
            this.pnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnExport;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblReport;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2CircleProgressBar prbChecklist;
        private System.Windows.Forms.Label lblChecklistComplete;
        private System.Windows.Forms.DataGridView dgvChecklist;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblHyphen;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2Button btnAllTime;
        private Guna.UI2.WinForms.Guna2Button btnClosed;
        private Guna.UI2.WinForms.Guna2Button btnInprogress;
        private Guna.UI2.WinForms.Guna2Button btnComplete;
        private Guna.UI2.WinForms.Guna2Button btnOpen;
        private Guna.UI2.WinForms.Guna2Button btnAll;
        private System.Windows.Forms.Label lblStauts;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
    }
}