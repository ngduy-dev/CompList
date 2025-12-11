namespace FinalProject.Views
{
    partial class FormChecklistItem
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDepartmentChecklist = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatuss = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCreatedDate = new System.Windows.Forms.Label();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblTasks = new System.Windows.Forms.Label();
            this.txtDescript = new System.Windows.Forms.RichTextBox();
            this.cmsType = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnReload = new Guna.UI2.WinForms.Guna2Button();
            this.btnReceiveResponse = new Guna.UI2.WinForms.Guna2Button();
            this.lblCreate = new System.Windows.Forms.Label();
            this.lblCreateBy = new System.Windows.Forms.Label();
            this.dgvChecklistItem = new System.Windows.Forms.DataGridView();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklistItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(31, 109);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1217, 42);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Checklist Number 1";
            // 
            // lblDepartmentChecklist
            // 
            this.lblDepartmentChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentChecklist.Location = new System.Drawing.Point(767, 205);
            this.lblDepartmentChecklist.Name = "lblDepartmentChecklist";
            this.lblDepartmentChecklist.Size = new System.Drawing.Size(148, 23);
            this.lblDepartmentChecklist.TabIndex = 9;
            this.lblDepartmentChecklist.Text = "Department:";
            // 
            // lblDue
            // 
            this.lblDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(767, 399);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(104, 23);
            this.lblDue.TabIndex = 10;
            this.lblDue.Text = "Due date:";
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateDate.Location = new System.Drawing.Point(767, 335);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(132, 23);
            this.lblCreateDate.TabIndex = 11;
            this.lblCreateDate.Text = "Created date:";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(33, 266);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(116, 23);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Description:";
            // 
            // lblStatuss
            // 
            this.lblStatuss.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatuss.Location = new System.Drawing.Point(34, 190);
            this.lblStatuss.Name = "lblStatuss";
            this.lblStatuss.Size = new System.Drawing.Size(111, 23);
            this.lblStatuss.TabIndex = 13;
            this.lblStatuss.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(185)))), ((int)(((byte)(53)))));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(151, 189);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 23);
            this.lblStatus.TabIndex = 17;
            this.lblStatus.Text = "Complete";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Location = new System.Drawing.Point(921, 335);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(174, 23);
            this.lblCreatedDate.TabIndex = 15;
            this.lblCreatedDate.Text = "Oct, 08, 2024";
            // 
            // lblDueDate
            // 
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(921, 399);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(146, 23);
            this.lblDueDate.TabIndex = 14;
            this.lblDueDate.Text = "Oct, 13, 2024";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(921, 205);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(275, 23);
            this.lblDepartment.TabIndex = 21;
            this.lblDepartment.Text = "Empty";
            // 
            // lblTasks
            // 
            this.lblTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasks.Location = new System.Drawing.Point(32, 457);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(144, 42);
            this.lblTasks.TabIndex = 22;
            this.lblTasks.Text = "Tasks";
            // 
            // txtDescript
            // 
            this.txtDescript.Location = new System.Drawing.Point(155, 266);
            this.txtDescript.Name = "txtDescript";
            this.txtDescript.ReadOnly = true;
            this.txtDescript.Size = new System.Drawing.Size(415, 154);
            this.txtDescript.TabIndex = 0;
            this.txtDescript.Text = "";
            // 
            // cmsType
            // 
            this.cmsType.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsType.Name = "guna2ContextMenuStrip1";
            this.cmsType.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsType.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsType.RenderStyle.ColorTable = null;
            this.cmsType.RenderStyle.RoundedEdges = true;
            this.cmsType.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsType.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmsType.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsType.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsType.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsType.Size = new System.Drawing.Size(61, 4);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(613, 457);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(160, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(788, 457);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(160, 35);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.buttonUpdate_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.BorderRadius = 5;
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(963, 457);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 35);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add new Task";
            this.btnAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.Transparent;
            this.btnReload.BorderRadius = 5;
            this.btnReload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReload.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnReload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReload.ForeColor = System.Drawing.Color.White;
            this.btnReload.Location = new System.Drawing.Point(438, 457);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(160, 35);
            this.btnReload.TabIndex = 1;
            this.btnReload.Text = "Reload";
            this.btnReload.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // btnReceiveResponse
            // 
            this.btnReceiveResponse.BackColor = System.Drawing.Color.Transparent;
            this.btnReceiveResponse.BorderRadius = 5;
            this.btnReceiveResponse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReceiveResponse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReceiveResponse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReceiveResponse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReceiveResponse.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnReceiveResponse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnReceiveResponse.ForeColor = System.Drawing.Color.White;
            this.btnReceiveResponse.Location = new System.Drawing.Point(1138, 457);
            this.btnReceiveResponse.Name = "btnReceiveResponse";
            this.btnReceiveResponse.Size = new System.Drawing.Size(160, 35);
            this.btnReceiveResponse.TabIndex = 5;
            this.btnReceiveResponse.Text = "Receive Response";
            this.btnReceiveResponse.Click += new System.EventHandler(this.btnReceiveResponse_Click);
            // 
            // lblCreate
            // 
            this.lblCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.Location = new System.Drawing.Point(767, 268);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(148, 23);
            this.lblCreate.TabIndex = 32;
            this.lblCreate.Text = "Create by: ";
            // 
            // lblCreateBy
            // 
            this.lblCreateBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateBy.Location = new System.Drawing.Point(921, 268);
            this.lblCreateBy.Name = "lblCreateBy";
            this.lblCreateBy.Size = new System.Drawing.Size(275, 23);
            this.lblCreateBy.TabIndex = 33;
            this.lblCreateBy.Text = "Empty";
            // 
            // dgvChecklistItem
            // 
            this.dgvChecklistItem.AllowUserToAddRows = false;
            this.dgvChecklistItem.AllowUserToDeleteRows = false;
            this.dgvChecklistItem.AllowUserToOrderColumns = true;
            this.dgvChecklistItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecklistItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvChecklistItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChecklistItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChecklistItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklistItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChecklistItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecklistItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvChecklistItem.EnableHeadersVisualStyles = false;
            this.dgvChecklistItem.GridColor = System.Drawing.Color.Black;
            this.dgvChecklistItem.Location = new System.Drawing.Point(38, 517);
            this.dgvChecklistItem.MultiSelect = false;
            this.dgvChecklistItem.Name = "dgvChecklistItem";
            this.dgvChecklistItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklistItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChecklistItem.RowHeadersVisible = false;
            this.dgvChecklistItem.RowHeadersWidth = 51;
            this.dgvChecklistItem.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvChecklistItem.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvChecklistItem.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.dgvChecklistItem.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvChecklistItem.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChecklistItem.RowTemplate.Height = 24;
            this.dgvChecklistItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChecklistItem.Size = new System.Drawing.Size(1427, 320);
            this.dgvChecklistItem.TabIndex = 69;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderRadius = 5;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(1313, 457);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(160, 35);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export PDF";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormChecklistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1642, 943);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvChecklistItem);
            this.Controls.Add(this.lblCreateBy);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.btnReceiveResponse);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDescript);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblStatuss);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblDepartmentChecklist);
            this.Controls.Add(this.lblTitle);
            this.MaximizeBox = false;
            this.Name = "FormChecklistItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChecklistCheck";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecklistItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDepartmentChecklist;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label lblCreateDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatuss;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCreatedDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblTasks;
        private System.Windows.Forms.RichTextBox txtDescript;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsType;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnReload;
        private Guna.UI2.WinForms.Guna2Button btnReceiveResponse;
        private System.Windows.Forms.Label lblCreate;
        private System.Windows.Forms.Label lblCreateBy;
        private System.Windows.Forms.DataGridView dgvChecklistItem;
        private Guna.UI2.WinForms.Guna2Button btnExport;
    }
}