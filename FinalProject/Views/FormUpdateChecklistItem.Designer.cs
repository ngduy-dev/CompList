namespace FinalProject.Views
{
    partial class FormUpdateChecklistItem
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
            this.txtTaskDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAssign = new System.Windows.Forms.Label();
            this.cmbEmployeeID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cmbIsComplete = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.lblIsComplete = new System.Windows.Forms.Label();
            this.lblChecklistID = new System.Windows.Forms.Label();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
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
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.Black;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.lblAssign);
            this.pnlBody.Controls.Add(this.cmbEmployeeID);
            this.pnlBody.Controls.Add(this.btnSave);
            this.pnlBody.Controls.Add(this.dtpDueDate);
            this.pnlBody.Controls.Add(this.cmbIsComplete);
            this.pnlBody.Controls.Add(this.lblDueDate);
            this.pnlBody.Controls.Add(this.lblIsComplete);
            this.pnlBody.Controls.Add(this.txtTaskDescription);
            this.pnlBody.Location = new System.Drawing.Point(37, 98);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1205, 580);
            this.pnlBody.TabIndex = 23;
            // 
            // lblAssign
            // 
            this.lblAssign.BackColor = System.Drawing.Color.Transparent;
            this.lblAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssign.Location = new System.Drawing.Point(49, 444);
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
            this.btnSave.Location = new System.Drawing.Point(595, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.buttonSaveChecklistItem_Click);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Checked = true;
            this.dtpDueDate.FillColor = System.Drawing.Color.White;
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new System.Drawing.Point(232, 524);
            this.dtpDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(284, 36);
            this.dtpDueDate.TabIndex = 3;
            this.dtpDueDate.Value = new System.DateTime(2024, 10, 30, 0, 24, 4, 459);
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
            "Not Complete"});
            this.cmbIsComplete.Location = new System.Drawing.Point(232, 350);
            this.cmbIsComplete.Name = "cmbIsComplete";
            this.cmbIsComplete.Size = new System.Drawing.Size(284, 36);
            this.cmbIsComplete.TabIndex = 1;
            // 
            // lblDueDate
            // 
            this.lblDueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDueDate.Location = new System.Drawing.Point(49, 531);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new System.Drawing.Size(100, 23);
            this.lblDueDate.TabIndex = 10;
            this.lblDueDate.Text = "Due Date";
            // 
            // lblIsComplete
            // 
            this.lblIsComplete.BackColor = System.Drawing.Color.Transparent;
            this.lblIsComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsComplete.Location = new System.Drawing.Point(49, 357);
            this.lblIsComplete.Name = "lblIsComplete";
            this.lblIsComplete.Size = new System.Drawing.Size(146, 23);
            this.lblIsComplete.TabIndex = 9;
            this.lblIsComplete.Text = "Is Completed";
            // 
            // lblChecklistID
            // 
            this.lblChecklistID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChecklistID.Location = new System.Drawing.Point(47, 48);
            this.lblChecklistID.Name = "lblChecklistID";
            this.lblChecklistID.Size = new System.Drawing.Size(560, 33);
            this.lblChecklistID.TabIndex = 24;
            this.lblChecklistID.Text = "Update for";
            // 
            // FormUpdateChecklistItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1278, 726);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.lblChecklistID);
            this.MaximizeBox = false;
            this.Name = "FormUpdateChecklistItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateChecklistItem";
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtTaskDescription;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private System.Windows.Forms.Label lblAssign;
        private Guna.UI2.WinForms.Guna2ComboBox cmbEmployeeID;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDueDate;
        private Guna.UI2.WinForms.Guna2ComboBox cmbIsComplete;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.Label lblIsComplete;
        private System.Windows.Forms.Label lblChecklistID;
    }
}