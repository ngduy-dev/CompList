namespace FinalProject.Views
{
    partial class FormBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmbChecklist = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblBoard = new System.Windows.Forms.Label();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.chtBoard = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvChecklist = new System.Windows.Forms.DataGridView();
            this.lblChecklistComplete = new System.Windows.Forms.Label();
            this.prbChecklist = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.lblHyphen = new System.Windows.Forms.Label();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnAllTime = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chtBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).BeginInit();
            this.SuspendLayout();
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
            this.pnlBody3.Size = new System.Drawing.Size(1540, 90);
            this.pnlBody3.TabIndex = 5;
            // 
            // pbxLogo
            // 
            this.pbxLogo.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.ErrorImage")));
            this.pbxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbxLogo.Image")));
            this.pbxLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxLogo.InitialImage")));
            this.pbxLogo.Location = new System.Drawing.Point(141, 10);
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
            // cmbChecklist
            // 
            this.cmbChecklist.BackColor = System.Drawing.Color.Transparent;
            this.cmbChecklist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbChecklist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChecklist.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChecklist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbChecklist.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChecklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbChecklist.ItemHeight = 30;
            this.cmbChecklist.Location = new System.Drawing.Point(34, 350);
            this.cmbChecklist.Margin = new System.Windows.Forms.Padding(2);
            this.cmbChecklist.Name = "cmbChecklist";
            this.cmbChecklist.Size = new System.Drawing.Size(245, 36);
            this.cmbChecklist.TabIndex = 38;
            this.cmbChecklist.SelectedIndexChanged += new System.EventHandler(this.cboChecklist_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(32, 324);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(198, 22);
            this.lblDepartment.TabIndex = 35;
            this.lblDepartment.Text = "Choose Checklist ID";
            // 
            // lblBoard
            // 
            this.lblBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoard.Location = new System.Drawing.Point(32, 111);
            this.lblBoard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoard.Name = "lblBoard";
            this.lblBoard.Size = new System.Drawing.Size(194, 32);
            this.lblBoard.TabIndex = 33;
            this.lblBoard.Text = "Board";
            // 
            // pnlBody2
            // 
            this.pnlBody2.AutoScroll = true;
            this.pnlBody2.Controls.Add(this.lblSearch);
            this.pnlBody2.Controls.Add(this.txtSearch);
            this.pnlBody2.Controls.Add(this.chtBoard);
            this.pnlBody2.Controls.Add(this.dgvChecklist);
            this.pnlBody2.Controls.Add(this.lblChecklistComplete);
            this.pnlBody2.Controls.Add(this.prbChecklist);
            this.pnlBody2.Controls.Add(this.lblDepartment);
            this.pnlBody2.Controls.Add(this.cmbChecklist);
            this.pnlBody2.Location = new System.Drawing.Point(0, 249);
            this.pnlBody2.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1642, 694);
            this.pnlBody2.TabIndex = 49;
            // 
            // lblSearch
            // 
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(364, 324);
            this.lblSearch.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(198, 22);
            this.lblSearch.TabIndex = 40;
            this.lblSearch.Text = "Search Checklist";
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
            this.txtSearch.Location = new System.Drawing.Point(368, 350);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(245, 36);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // chtBoard
            // 
            this.chtBoard.BackColor = System.Drawing.SystemColors.Control;
            this.chtBoard.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chtBoard.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtBoard.Legends.Add(legend1);
            this.chtBoard.Location = new System.Drawing.Point(2, -1);
            this.chtBoard.Margin = new System.Windows.Forms.Padding(2);
            this.chtBoard.Name = "chtBoard";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chtBoard.Series.Add(series1);
            this.chtBoard.Size = new System.Drawing.Size(822, 300);
            this.chtBoard.TabIndex = 31;
            this.chtBoard.Text = "chart1";
            // 
            // dgvChecklist
            // 
            this.dgvChecklist.AllowUserToAddRows = false;
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
            this.dgvChecklist.Location = new System.Drawing.Point(34, 426);
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
            this.dgvChecklist.Size = new System.Drawing.Size(1121, 228);
            this.dgvChecklist.TabIndex = 30;
            // 
            // lblChecklistComplete
            // 
            this.lblChecklistComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistComplete.Location = new System.Drawing.Point(1306, 631);
            this.lblChecklistComplete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChecklistComplete.Name = "lblChecklistComplete";
            this.lblChecklistComplete.Size = new System.Drawing.Size(204, 22);
            this.lblChecklistComplete.TabIndex = 1;
            // 
            // prbChecklist
            // 
            this.prbChecklist.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.prbChecklist.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.prbChecklist.ForeColor = System.Drawing.Color.White;
            this.prbChecklist.Location = new System.Drawing.Point(1272, 350);
            this.prbChecklist.Margin = new System.Windows.Forms.Padding(2);
            this.prbChecklist.Minimum = 0;
            this.prbChecklist.Name = "prbChecklist";
            this.prbChecklist.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.prbChecklist.Size = new System.Drawing.Size(262, 262);
            this.prbChecklist.TabIndex = 0;
            this.prbChecklist.Text = "guna2CircleProgressBar1";
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.Transparent;
            this.btnFilter.BorderRadius = 5;
            this.btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(1008, 209);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(148, 35);
            this.btnFilter.TabIndex = 60;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.Location = new System.Drawing.Point(32, 181);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(198, 22);
            this.lblFilter.TabIndex = 59;
            this.lblFilter.Text = "Filter";
            // 
            // lblHyphen
            // 
            this.lblHyphen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHyphen.Location = new System.Drawing.Point(342, 208);
            this.lblHyphen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHyphen.Name = "lblHyphen";
            this.lblHyphen.Size = new System.Drawing.Size(22, 22);
            this.lblHyphen.TabIndex = 58;
            this.lblHyphen.Text = "-";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BackColor = System.Drawing.Color.White;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(382, 208);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(288, 36);
            this.dtpEndDate.TabIndex = 57;
            this.dtpEndDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.BackColor = System.Drawing.Color.White;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(38, 208);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(288, 36);
            this.dtpStartDate.TabIndex = 56;
            this.dtpStartDate.Value = new System.DateTime(2024, 11, 10, 0, 5, 2, 620);
            // 
            // btnAllTime
            // 
            this.btnAllTime.BackColor = System.Drawing.Color.Transparent;
            this.btnAllTime.BorderRadius = 5;
            this.btnAllTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAllTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAllTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAllTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAllTime.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAllTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAllTime.ForeColor = System.Drawing.Color.White;
            this.btnAllTime.Location = new System.Drawing.Point(830, 209);
            this.btnAllTime.Margin = new System.Windows.Forms.Padding(2);
            this.btnAllTime.Name = "btnAllTime";
            this.btnAllTime.Size = new System.Drawing.Size(148, 35);
            this.btnAllTime.TabIndex = 61;
            this.btnAllTime.Text = "All Time";
            this.btnAllTime.Click += new System.EventHandler(this.btnAllTime_Click);
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1540, 845);
            this.Controls.Add(this.btnAllTime);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.lblHyphen);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.pnlBody2);
            this.Controls.Add(this.lblBoard);
            this.Controls.Add(this.pnlBody3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "FormBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Board_Load);
            this.pnlBody3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chtBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2ComboBox cmbChecklist;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblBoard;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2CircleProgressBar prbChecklist;
        private System.Windows.Forms.Label lblChecklistComplete;
        private System.Windows.Forms.DataGridView dgvChecklist;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtBoard;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblHyphen;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2Button btnAllTime;
        private System.Windows.Forms.PictureBox pbxLogo;
    }
}