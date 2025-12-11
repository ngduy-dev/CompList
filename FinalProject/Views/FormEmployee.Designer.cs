namespace FinalProject.Views
{
    partial class FormEmployee
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
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnInfomation = new Guna.UI2.WinForms.Guna2Button();
            this.cmbDepartment = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody2
            // 
            this.pnlBody2.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody2.Controls.Add(this.dgvEmployee);
            this.pnlBody2.Controls.Add(this.lblSearch);
            this.pnlBody2.Controls.Add(this.btnReload);
            this.pnlBody2.Controls.Add(this.txtSearch);
            this.pnlBody2.Controls.Add(this.btnDelete);
            this.pnlBody2.Controls.Add(this.btnAdd);
            this.pnlBody2.Controls.Add(this.btnInfomation);
            this.pnlBody2.Controls.Add(this.cmbDepartment);
            this.pnlBody2.Controls.Add(this.lblDepartment);
            this.pnlBody2.Location = new System.Drawing.Point(37, 181);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1552, 750);
            this.pnlBody2.TabIndex = 69;
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.AllowUserToAddRows = false;
            this.dgvEmployee.AllowUserToDeleteRows = false;
            this.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvEmployee.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmployee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvEmployee.EnableHeadersVisualStyles = false;
            this.dgvEmployee.GridColor = System.Drawing.Color.Black;
            this.dgvEmployee.Location = new System.Drawing.Point(32, 173);
            this.dgvEmployee.MultiSelect = false;
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployee.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmployee.RowHeadersVisible = false;
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvEmployee.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvEmployee.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvEmployee.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvEmployee.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmployee.RowTemplate.Height = 24;
            this.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployee.Size = new System.Drawing.Size(1478, 480);
            this.dgvEmployee.TabIndex = 74;
            this.dgvEmployee.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEmployee_MouseClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(33, 99);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 20);
            this.lblSearch.TabIndex = 73;
            this.lblSearch.Text = "Search";
            // 
            // btnReload
            // 
            this.btnReload.BorderRadius = 7;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(661, 82);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(180, 45);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
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
            this.txtSearch.Location = new System.Drawing.Point(182, 91);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(414, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 7;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1330, 82);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(180, 45);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 7;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1107, 82);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnInfomation
            // 
            this.btnInfomation.BorderRadius = 7;
            this.btnInfomation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnInfomation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnInfomation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnInfomation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnInfomation.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnInfomation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnInfomation.ForeColor = System.Drawing.Color.White;
            this.btnInfomation.Location = new System.Drawing.Point(884, 82);
            this.btnInfomation.Name = "btnInfomation";
            this.btnInfomation.Size = new System.Drawing.Size(180, 45);
            this.btnInfomation.TabIndex = 3;
            this.btnInfomation.Text = "Infomation";
            this.btnInfomation.Click += new System.EventHandler(this.btnInfomation_Click);
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
            this.cmbDepartment.Location = new System.Drawing.Point(182, 25);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(414, 36);
            this.cmbDepartment.TabIndex = 0;
            this.cmbDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(33, 33);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(107, 20);
            this.lblDepartment.TabIndex = 3;
            this.lblDepartment.Text = "Department";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(66, 198);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 16);
            this.lblUser.TabIndex = 71;
            this.lblUser.Text = "Search";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(120, 198);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(407, 22);
            this.txtUser.TabIndex = 70;
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
            this.pbxIcon.Image = global::FinalProject.Properties.Resources.Users;
            this.pbxIcon.ImageRotate = 0F;
            this.pbxIcon.Location = new System.Drawing.Point(10, 10);
            this.pbxIcon.Name = "pbxIcon";
            this.pbxIcon.Size = new System.Drawing.Size(50, 50);
            this.pbxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxIcon.TabIndex = 2;
            this.pbxIcon.TabStop = false;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(116, 36);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(90, 20);
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Employee";
            // 
            // pnlBody3
            // 
            this.pnlBody3.Controls.Add(this.lblEmployee);
            this.pnlBody3.Controls.Add(this.pnlBody1);
            this.pnlBody3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody3.FillColor = System.Drawing.Color.White;
            this.pnlBody3.Location = new System.Drawing.Point(0, 0);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1642, 90);
            this.pnlBody3.TabIndex = 68;
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.pnlBody2);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.pnlBody3);
            this.MaximizeBox = false;
            this.Name = "FormEmployee";
            this.Text = "Employee";
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody3.ResumeLayout(false);
            this.pnlBody3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblDepartment;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDepartment;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnInfomation;
        private Guna.UI2.WinForms.Guna2Button btnReload;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private System.Windows.Forms.Label lblEmployee;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
    }
}