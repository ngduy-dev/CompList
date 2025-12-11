namespace FinalProject.Views
{
    partial class formAddChecklistItem
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
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddChecklistItem = new Guna.UI2.WinForms.Guna2Button();
            this.lblAssign = new System.Windows.Forms.Label();
            this.cmbEmployeeID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbIsComplete = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblComplete = new System.Windows.Forms.Label();
            this.txtTaskDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTitleChecklist = new System.Windows.Forms.Label();
            this.lblChecklistID = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.Black;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.btnAddChecklistItem);
            this.pnlBody.Controls.Add(this.lblAssign);
            this.pnlBody.Controls.Add(this.cmbEmployeeID);
            this.pnlBody.Controls.Add(this.dtpDueDate);
            this.pnlBody.Controls.Add(this.cmbIsComplete);
            this.pnlBody.Controls.Add(this.lblDueDate);
            this.pnlBody.Controls.Add(this.lblComplete);
            this.pnlBody.Controls.Add(this.txtTaskDescription);
            this.pnlBody.Location = new System.Drawing.Point(17, 59);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1205, 580);
            this.pnlBody.TabIndex = 20;
            // 
            // btnAddChecklistItem
            // 
            this.btnAddChecklistItem.BackColor = System.Drawing.Color.Transparent;
            this.btnAddChecklistItem.BorderRadius = 5;
            this.btnAddChecklistItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChecklistItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddChecklistItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddChecklistItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddChecklistItem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(76)))), ((int)(((byte)(172)))));
            this.btnAddChecklistItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddChecklistItem.ForeColor = System.Drawing.Color.White;
            this.btnAddChecklistItem.Location = new System.Drawing.Point(565, 526);
            this.btnAddChecklistItem.Name = "btnAddChecklistItem";
            this.btnAddChecklistItem.Size = new System.Drawing.Size(160, 35);
            this.btnAddChecklistItem.TabIndex = 4;
            this.btnAddChecklistItem.Text = "Add task";
            this.btnAddChecklistItem.Click += new System.EventHandler(this.btnAddChecklistItem_Click);
            // 
            // lblAssign
            // 
            this.lblAssign.BackColor = System.Drawing.Color.Transparent;
            this.lblAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssign.Location = new System.Drawing.Point(43, 444);
            this.lblAssign.Name = "lblAssign";
            this.lblAssign.Size = new System.Drawing.Size(146, 23);
            this.lblAssign.TabIndex = 19;
            this.lblAssign.Text = "Assign to";
            // 
            // cmbEmployeeID
            // 
            this.cmbEmployeeID.BackColor = System.Drawing.Color.Transparent;
            this.cmbEmployeeID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEmployeeID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbEmployeeID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEmployeeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbEmployeeID.ItemHeight = 30;
            this.cmbEmployeeID.Location = new System.Drawing.Point(232, 437);
            this.cmbEmployeeID.Name = "cmbEmployeeID";
            this.cmbEmployeeID.Size = new System.Drawing.Size(284, 36);
            this.cmbEmployeeID.TabIndex = 2;
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Checked = true;
            this.dtpDueDate.FillColor = System.Drawing.Color.White;
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(232, 525);
            this.dtpDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(284, 36);
            this.dtpDueDate.TabIndex = 3;
            this.dtpDueDate.Value = new System.DateTime(2024, 11, 4, 0, 0, 0, 0);
            // 
            // cmbIsComplete
            // 
            this.cmbIsComplete.BackColor = System.Drawing.Color.Transparent;
            this.cmbIsComplete.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbIsComplete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsComplete.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbIsComplete.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbIsComplete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbIsComplete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbIsComplete.ItemHeight = 30;
            this.cmbIsComplete.Items.AddRange(new object[] {
            "Complete",
            "Not complete"});
            this.cmbIsComplete.Location = new System.Drawing.Point(232, 350);
            this.cmbIsComplete.Name = "cmbIsComplete";
            this.cmbIsComplete.Size = new System.Drawing.Size(284, 36);
            this.cmbIsComplete.TabIndex = 1;
            // 
            // lblDueDate
            // 
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(43, 532);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
            this.lblDueDate.TabIndex = 10;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblComplete
            // 
            this.lblComplete.BackColor = System.Drawing.Color.Transparent;
            this.lblComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplete.Location = new System.Drawing.Point(43, 357);
            this.lblComplete.Name = "lblComplete";
            this.lblComplete.Size = new System.Drawing.Size(146, 23);
            this.lblComplete.TabIndex = 9;
            this.lblComplete.Text = "Is Completed";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTaskDescription.DefaultText = "";
            this.txtTaskDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTaskDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTaskDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaskDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTaskDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaskDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaskDescription.ForeColor = System.Drawing.Color.Black;
            this.txtTaskDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTaskDescription.Location = new System.Drawing.Point(47, 54);
            this.txtTaskDescription.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTaskDescription.Multiline = true;
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.PasswordChar = '\0';
            this.txtTaskDescription.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtTaskDescription.PlaceholderText = "Task description";
            this.txtTaskDescription.SelectedText = "";
            this.txtTaskDescription.Size = new System.Drawing.Size(1102, 211);
            this.txtTaskDescription.TabIndex = 0;
            // 
            // lblTitleChecklist
            // 
            this.lblTitleChecklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChecklist.Location = new System.Drawing.Point(27, 9);
            this.lblTitleChecklist.Name = "lblTitleChecklist";
            this.lblTitleChecklist.Size = new System.Drawing.Size(1195, 33);
            this.lblTitleChecklist.TabIndex = 22;
            // 
            // lblChecklistID
            // 
            this.lblChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistID.Location = new System.Drawing.Point(12, 9);
            this.lblChecklistID.Name = "lblChecklistID";
            this.lblChecklistID.Size = new System.Drawing.Size(973, 33);
            this.lblChecklistID.TabIndex = 23;
            // 
            // formAddChecklistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 726);
            this.Controls.Add(this.lblChecklistID);
            this.Controls.Add(this.lblTitleChecklist);
            this.Controls.Add(this.pnlBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "formAddChecklistItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddChecklistItem";
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDueDate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbIsComplete;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblComplete;
        private Guna.UI2.WinForms.Guna2TextBox txtTaskDescription;
        private System.Windows.Forms.Label lblTitleChecklist;
        private System.Windows.Forms.Label lblAssign;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEmployeeID;
        private System.Windows.Forms.Label lblChecklistID;
        private Guna.UI2.WinForms.Guna2Button btnAddChecklistItem;
    }
}