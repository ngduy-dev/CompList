namespace FinalProject.Views
{
    partial class FormDepartment
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
            this.btnUnlock = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnBlock = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitleDepartment = new System.Windows.Forms.Label();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody2
            // 
            this.pnlBody2.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody2.Controls.Add(this.btnUnlock);
            this.pnlBody2.Controls.Add(this.dgvDepartment);
            this.pnlBody2.Controls.Add(this.lblSearch);
            this.pnlBody2.Controls.Add(this.btnReload);
            this.pnlBody2.Controls.Add(this.txtSearch);
            this.pnlBody2.Controls.Add(this.btnBlock);
            this.pnlBody2.Controls.Add(this.btnAdd);
            this.pnlBody2.Location = new System.Drawing.Point(37, 137);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1552, 775);
            this.pnlBody2.TabIndex = 73;
            // 
            // btnUnlock
            // 
            this.btnUnlock.BorderRadius = 7;
            this.btnUnlock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUnlock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUnlock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUnlock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUnlock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnUnlock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUnlock.ForeColor = System.Drawing.Color.White;
            this.btnUnlock.Location = new System.Drawing.Point(1269, 87);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(180, 45);
            this.btnUnlock.TabIndex = 4;
            this.btnUnlock.Text = "Unblock Department";
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click_1);
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AllowUserToAddRows = false;
            this.dgvDepartment.AllowUserToDeleteRows = false;
            this.dgvDepartment.AllowUserToOrderColumns = true;
            this.dgvDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartment.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDepartment.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDepartment.EnableHeadersVisualStyles = false;
            this.dgvDepartment.GridColor = System.Drawing.Color.Black;
            this.dgvDepartment.Location = new System.Drawing.Point(8, 187);
            this.dgvDepartment.MultiSelect = false;
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartment.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDepartment.RowHeadersVisible = false;
            this.dgvDepartment.RowHeadersWidth = 51;
            this.dgvDepartment.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDepartment.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDepartment.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvDepartment.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDepartment.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDepartment.RowTemplate.Height = 24;
            this.dgvDepartment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartment.Size = new System.Drawing.Size(1537, 400);
            this.dgvDepartment.TabIndex = 74;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(71, 100);
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
            this.btnReload.Location = new System.Drawing.Point(603, 87);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(180, 45);
            this.btnReload.TabIndex = 1;
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
            this.txtSearch.Size = new System.Drawing.Size(397, 36);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnBlock
            // 
            this.btnBlock.BorderRadius = 7;
            this.btnBlock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBlock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBlock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBlock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBlock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnBlock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBlock.ForeColor = System.Drawing.Color.White;
            this.btnBlock.Location = new System.Drawing.Point(1047, 87);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(180, 45);
            this.btnBlock.TabIndex = 3;
            this.btnBlock.Text = "Block Department";
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
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
            this.btnAdd.Location = new System.Drawing.Point(825, 87);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 45);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add new Department";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTitleDepartment
            // 
            this.lblTitleDepartment.AutoSize = true;
            this.lblTitleDepartment.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleDepartment.Location = new System.Drawing.Point(116, 36);
            this.lblTitleDepartment.Name = "lblTitleDepartment";
            this.lblTitleDepartment.Size = new System.Drawing.Size(107, 20);
            this.lblTitleDepartment.TabIndex = 2;
            this.lblTitleDepartment.Text = "Department";
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
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(66, 191);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(50, 16);
            this.lblDepartment.TabIndex = 75;
            this.lblDepartment.Text = "Search";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 191);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(407, 22);
            this.txtName.TabIndex = 74;
            // 
            // pnlBody3
            // 
            this.pnlBody3.Controls.Add(this.lblTitleDepartment);
            this.pnlBody3.Controls.Add(this.pnlBody1);
            this.pnlBody3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody3.FillColor = System.Drawing.Color.White;
            this.pnlBody3.Location = new System.Drawing.Point(0, 0);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1642, 90);
            this.pnlBody3.TabIndex = 72;
            // 
            // FormDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.pnlBody2);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pnlBody3);
            this.MaximizeBox = false;
            this.Name = "FormDepartment";
            this.Text = "Department";
            this.Load += new System.EventHandler(this.Department_Load);
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody3.ResumeLayout(false);
            this.pnlBody3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2Button btnReload;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnBlock;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private System.Windows.Forms.Label lblTitleDepartment;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtName;
        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private System.Windows.Forms.DataGridView dgvDepartment;
        private Guna.UI2.WinForms.Guna2Button btnUnlock;
    }
}