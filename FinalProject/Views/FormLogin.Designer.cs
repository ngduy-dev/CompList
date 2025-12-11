namespace FinalProject.Views
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            this.eliSeePass = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.dgcSeePass = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlBody1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbShowPassword = new System.Windows.Forms.PictureBox();
            this.btnForgetPassword = new Guna.UI2.WinForms.Guna2Button();
            this.txtVersion = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.pbxLogo = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtLogin = new Guna.UI2.WinForms.Guna2Button();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUserID = new Guna.UI2.WinForms.Guna2TextBox();
            this.swfSeepass = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlBody2 = new Guna.UI2.WinForms.Guna2Panel();
            this.gbxForgetPass = new Guna.UI2.WinForms.Guna2GroupBox();
            this.txtEnterEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pbxVideo = new System.Windows.Forms.PictureBox();
            this.pnlBody1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.pnlBody2.SuspendLayout();
            this.gbxForgetPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // eliSeePass
            // 
            this.eliSeePass.BorderRadius = 50;
            this.eliSeePass.TargetControl = this;
            // 
            // dgcSeePass
            // 
            this.dgcSeePass.DockIndicatorTransparencyValue = 0.6D;
            this.dgcSeePass.TargetControl = this.pnlBody1;
            this.dgcSeePass.UseTransparentDrag = true;
            // 
            // pnlBody1
            // 
            this.pnlBody1.BackColor = System.Drawing.Color.White;
            this.pnlBody1.Controls.Add(this.pbShowPassword);
            this.pnlBody1.Controls.Add(this.btnForgetPassword);
            this.pnlBody1.Controls.Add(this.txtVersion);
            this.pnlBody1.Controls.Add(this.btnExit);
            this.pnlBody1.Controls.Add(this.pbxLogo);
            this.pnlBody1.Controls.Add(this.txtLogin);
            this.pnlBody1.Controls.Add(this.txtPassword);
            this.pnlBody1.Controls.Add(this.txtUserID);
            this.pnlBody1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBody1.Location = new System.Drawing.Point(0, 0);
            this.pnlBody1.Name = "pnlBody1";
            this.pnlBody1.Size = new System.Drawing.Size(424, 700);
            this.pnlBody1.TabIndex = 3;
            // 
            // pbShowPassword
            // 
            this.pbShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.pbShowPassword.Image = global::FinalProject.Properties.Resources.show;
            this.pbShowPassword.Location = new System.Drawing.Point(344, 395);
            this.pbShowPassword.Name = "pbShowPassword";
            this.pbShowPassword.Size = new System.Drawing.Size(36, 35);
            this.pbShowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShowPassword.TabIndex = 10;
            this.pbShowPassword.TabStop = false;
            this.pbShowPassword.Click += new System.EventHandler(this.pbShowPassword_Click);
            // 
            // btnForgetPassword
            // 
            this.btnForgetPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnForgetPassword.BorderColor = System.Drawing.Color.White;
            this.btnForgetPassword.BorderRadius = 10;
            this.btnForgetPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnForgetPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnForgetPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnForgetPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnForgetPassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.btnForgetPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnForgetPassword.ForeColor = System.Drawing.Color.White;
            this.btnForgetPassword.Location = new System.Drawing.Point(209, 481);
            this.btnForgetPassword.Name = "btnForgetPassword";
            this.btnForgetPassword.Size = new System.Drawing.Size(180, 45);
            this.btnForgetPassword.TabIndex = 4;
            this.btnForgetPassword.Text = "Forget password?";
            this.btnForgetPassword.UseTransparentBackground = true;
            this.btnForgetPassword.Click += new System.EventHandler(this.btnForgetPassword_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.AutoSize = true;
            this.txtVersion.Font = new System.Drawing.Font("Yu Gothic UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.Location = new System.Drawing.Point(12, 674);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(32, 15);
            this.txtVersion.TabIndex = 9;
            this.txtVersion.Text = "V 1.0";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderColor = System.Drawing.Color.Red;
            this.btnExit.BorderRadius = 10;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(118, 568);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseTransparentBackground = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.FillColor = System.Drawing.Color.Transparent;
            this.pbxLogo.Image = global::FinalProject.Properties.Resources.Logo_Name_Image;
            this.pbxLogo.ImageRotate = 0F;
            this.pbxLogo.Location = new System.Drawing.Point(78, 50);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(253, 208);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 7;
            this.pbxLogo.TabStop = false;
            this.pbxLogo.UseTransparentBackground = true;
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.Transparent;
            this.txtLogin.BorderColor = System.Drawing.Color.White;
            this.txtLogin.BorderRadius = 10;
            this.txtLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.txtLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.txtLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.txtLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.txtLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtLogin.ForeColor = System.Drawing.Color.White;
            this.txtLogin.Location = new System.Drawing.Point(23, 481);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(180, 45);
            this.txtLogin.TabIndex = 3;
            this.txtLogin.Text = "Log in";
            this.txtLogin.UseTransparentBackground = true;
            this.txtLogin.Click += new System.EventHandler(this.txtLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Animated = true;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.BorderThickness = 3;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(23, 388);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(371, 48);
            this.txtPassword.TabIndex = 2;
            // 
            // txtUserID
            // 
            this.txtUserID.Animated = true;
            this.txtUserID.BackColor = System.Drawing.Color.White;
            this.txtUserID.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.txtUserID.BorderRadius = 10;
            this.txtUserID.BorderThickness = 3;
            this.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserID.DefaultText = "";
            this.txtUserID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUserID.ForeColor = System.Drawing.Color.Black;
            this.txtUserID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserID.Location = new System.Drawing.Point(23, 287);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.PasswordChar = '\0';
            this.txtUserID.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtUserID.PlaceholderText = "ID";
            this.txtUserID.SelectedText = "";
            this.txtUserID.Size = new System.Drawing.Size(371, 48);
            this.txtUserID.TabIndex = 1;
            // 
            // swfSeepass
            // 
            this.swfSeepass.BorderRadius = 6;
            this.swfSeepass.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(188)))), ((int)(((byte)(197)))));
            this.swfSeepass.TargetForm = this;
            // 
            // pnlBody2
            // 
            this.pnlBody2.BackgroundImage = global::FinalProject.Properties.Resources.video;
            this.pnlBody2.Controls.Add(this.gbxForgetPass);
            this.pnlBody2.Controls.Add(this.pbxVideo);
            this.pnlBody2.Location = new System.Drawing.Point(420, 0);
            this.pnlBody2.Name = "pnlBody2";
            this.pnlBody2.Size = new System.Drawing.Size(1242, 700);
            this.pnlBody2.TabIndex = 4;
            // 
            // gbxForgetPass
            // 
            this.gbxForgetPass.Controls.Add(this.txtEnterEmail);
            this.gbxForgetPass.Controls.Add(this.btnNext);
            this.gbxForgetPass.Controls.Add(this.btnCancel);
            this.gbxForgetPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gbxForgetPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbxForgetPass.Location = new System.Drawing.Point(251, 241);
            this.gbxForgetPass.Name = "gbxForgetPass";
            this.gbxForgetPass.Size = new System.Drawing.Size(464, 232);
            this.gbxForgetPass.TabIndex = 0;
            this.gbxForgetPass.Text = "Forget password";
            this.gbxForgetPass.Visible = false;
            // 
            // txtEnterEmail
            // 
            this.txtEnterEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEnterEmail.DefaultText = "";
            this.txtEnterEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEnterEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEnterEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEnterEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEnterEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEnterEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEnterEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEnterEmail.Location = new System.Drawing.Point(47, 78);
            this.txtEnterEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEnterEmail.Name = "txtEnterEmail";
            this.txtEnterEmail.PasswordChar = '\0';
            this.txtEnterEmail.PlaceholderText = "Please enter your email address";
            this.txtEnterEmail.SelectedText = "";
            this.txtEnterEmail.ShadowDecoration.Color = System.Drawing.Color.BlanchedAlmond;
            this.txtEnterEmail.Size = new System.Drawing.Size(363, 48);
            this.txtEnterEmail.TabIndex = 14;
            this.txtEnterEmail.Tag = "";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderColor = System.Drawing.Color.White;
            this.btnNext.BorderRadius = 10;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(173)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(283, 162);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(127, 42);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.Red;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(47, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 42);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseTransparentBackground = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbxVideo
            // 
            this.pbxVideo.Image = global::FinalProject.Properties.Resources.video;
            this.pbxVideo.Location = new System.Drawing.Point(0, 0);
            this.pbxVideo.Name = "pbxVideo";
            this.pbxVideo.Size = new System.Drawing.Size(1239, 700);
            this.pbxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxVideo.TabIndex = 0;
            this.pbxVideo.TabStop = false;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.txtLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1662, 700);
            this.Controls.Add(this.pnlBody2);
            this.Controls.Add(this.pnlBody1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.pnlBody1.ResumeLayout(false);
            this.pnlBody1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.pnlBody2.ResumeLayout(false);
            this.gbxForgetPass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxVideo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse eliSeePass;
        private Guna.UI2.WinForms.Guna2DragControl dgcSeePass;
        private Guna.UI2.WinForms.Guna2Panel pnlBody1;
        private Guna.UI2.WinForms.Guna2TextBox txtUserID;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2Button txtLogin;
        private Guna.UI2.WinForms.Guna2ShadowForm swfSeepass;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Label txtVersion;
        private Guna.UI2.WinForms.Guna2PictureBox pbxLogo;
        private Guna.UI2.WinForms.Guna2Panel pnlBody2;
        private Guna.UI2.WinForms.Guna2Button btnForgetPassword;
        private Guna.UI2.WinForms.Guna2GroupBox gbxForgetPass;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtEnterEmail;
        private System.Windows.Forms.PictureBox pbxVideo;
        private System.Windows.Forms.PictureBox pbShowPassword;
    }
}

