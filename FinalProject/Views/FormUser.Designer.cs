namespace FinalProject.Views
{
    partial class FormUser
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
            this.pnlBody3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.btnUnblock = new Guna.UI2.WinForms.Guna2Button();
            this.btnBlock = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLogoUser = new System.Windows.Forms.Label();
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbxIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBody3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            this.pnlBody2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody3
            // 
            this.pnlBody3.BackColor = System.Drawing.Color.Transparent;
            this.pnlBody3.Controls.Add(this.btnReload);
            this.pnlBody3.Controls.Add(this.btnUnblock);
            this.pnlBody3.Controls.Add(this.btnBlock);
            this.pnlBody3.Controls.Add(this.btnAdd);
            this.pnlBody3.Controls.Add(this.dgvUser);
            this.pnlBody3.Controls.Add(this.lblSearch);
            this.pnlBody3.Controls.Add(this.txtSearch);
            this.pnlBody3.Location = new System.Drawing.Point(37, 122);
            this.pnlBody3.Name = "pnlBody3";
            this.pnlBody3.Size = new System.Drawing.Size(1552, 703);
            this.pnlBody3.TabIndex = 65;
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
            this.btnReload.Location = new System.Drawing.Point(694, 98);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(130, 45);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnUnblock
            // 
            this.btnUnblock.BorderRadius = 7;
            this.btnUnblock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUnblock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUnblock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUnblock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUnblock.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnUnblock.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUnblock.ForeColor = System.Drawing.Color.White;
            this.btnUnblock.Location = new System.Drawing.Point(1186, 98);
            this.btnUnblock.Name = "btnUnblock";
            this.btnUnblock.Size = new System.Drawing.Size(130, 45);
            this.btnUnblock.TabIndex = 4;
            this.btnUnblock.Text = "Unblock User";
            this.btnUnblock.Click += new System.EventHandler(this.btnUnblock_Click);
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
            this.btnBlock.Location = new System.Drawing.Point(1023, 98);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(130, 45);
            this.btnBlock.TabIndex = 3;
            this.btnBlock.Text = "Block user";
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
            this.btnAdd.Location = new System.Drawing.Point(856, 98);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 45);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add user";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.GridColor = System.Drawing.Color.Black;
            this.dgvUser.Location = new System.Drawing.Point(32, 181);
            this.dgvUser.MultiSelect = false;
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowHeadersWidth = 51;
            this.dgvUser.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvUser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvUser.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvUser.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUser.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowTemplate.Height = 24;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(1471, 519);
            this.dgvUser.TabIndex = 68;
            this.dgvUser.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewUser_MouseClick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(67, 105);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(68, 20);
            this.lblSearch.TabIndex = 67;
            this.lblSearch.Text = "Search";
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
            this.txtSearch.Location = new System.Drawing.Point(193, 98);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(473, 45);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblLogoUser
            // 
            this.lblLogoUser.AutoSize = true;
            this.lblLogoUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLogoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogoUser.Location = new System.Drawing.Point(116, 37);
            this.lblLogoUser.Name = "lblLogoUser";
            this.lblLogoUser.Size = new System.Drawing.Size(49, 20);
            this.lblLogoUser.TabIndex = 2;
            this.lblLogoUser.Text = "User";
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
            // pnlBody2
            // 
            this.pnlBody2.Controls.Add(this.lblLogoUser);
            this.pnlBody2.Controls.Add(this.pnlBody1);
            this.pnlBody2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBody2.FillColor = System.Drawing.Color.White;
            this.pnlBody2.Location = new System.Drawing.Point(0, 0);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1642, 90);
            this.pnlBody2.TabIndex = 50;
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.pnlBody3);
            this.Controls.Add(this.pnlBody2);
            this.MaximizeBox = false;
            this.Name = "FormUser";
            this.Text = "User";
            this.pnlBody3.ResumeLayout(false);
            this.pnlBody3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.pnlBody1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            this.pnlBody2.ResumeLayout(false);
            this.pnlBody2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlBody3;
        private System.Windows.Forms.Label lblLogoUser;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2PictureBox pbxIcon;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvUser;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnUnblock;
        private Guna.UI2.WinForms.Guna2Button btnBlock;
        private Guna.UI2.WinForms.Guna2Button btnReload;
    }
}