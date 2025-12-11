namespace FinalProject.Views
{
    partial class FormResetPassword
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
            this.txtVerifyNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNewPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtVerifyNewPass
            // 
            this.txtVerifyNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVerifyNewPass.DefaultText = "";
            this.txtVerifyNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtVerifyNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtVerifyNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerifyNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtVerifyNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerifyNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVerifyNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtVerifyNewPass.Location = new System.Drawing.Point(35, 203);
            this.txtVerifyNewPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVerifyNewPass.Name = "txtVerifyNewPass";
            this.txtVerifyNewPass.PasswordChar = '*';
            this.txtVerifyNewPass.PlaceholderText = "Verify new password";
            this.txtVerifyNewPass.SelectedText = "";
            this.txtVerifyNewPass.ShadowDecoration.Color = System.Drawing.Color.BlanchedAlmond;
            this.txtVerifyNewPass.Size = new System.Drawing.Size(363, 48);
            this.txtVerifyNewPass.TabIndex = 2;
            this.txtVerifyNewPass.Tag = "";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPass.DefaultText = "";
            this.txtNewPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNewPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPass.Location = new System.Drawing.Point(35, 123);
            this.txtNewPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.PlaceholderText = "New password";
            this.txtNewPass.SelectedText = "";
            this.txtNewPass.ShadowDecoration.Color = System.Drawing.Color.BlanchedAlmond;
            this.txtNewPass.Size = new System.Drawing.Size(363, 48);
            this.txtNewPass.TabIndex = 1;
            this.txtNewPass.Tag = "";
            // 
            // txtOTP
            // 
            this.txtOTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOTP.DefaultText = "";
            this.txtOTP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOTP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOTP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOTP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOTP.Location = new System.Drawing.Point(35, 41);
            this.txtOTP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.PasswordChar = '\0';
            this.txtOTP.PlaceholderText = "Check your email and enter OTP";
            this.txtOTP.SelectedText = "";
            this.txtOTP.ShadowDecoration.Color = System.Drawing.Color.BlanchedAlmond;
            this.txtOTP.Size = new System.Drawing.Size(363, 48);
            this.txtOTP.TabIndex = 0;
            this.txtOTP.Tag = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.White;
            this.btnSave.BorderRadius = 10;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(271, 273);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 42);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.White;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(35, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 42);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseTransparentBackground = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel1_Click);
            // 
            // FormResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 362);
            this.Controls.Add(this.txtVerifyNewPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOTP);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.MinimizeBox = false;
            this.Name = "FormResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPassword";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtVerifyNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtNewPass;
        private Guna.UI2.WinForms.Guna2TextBox txtOTP;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}