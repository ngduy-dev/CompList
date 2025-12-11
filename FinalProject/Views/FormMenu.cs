using FinalProject.Models;
using FinalProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.Views
{
    public partial class FormMenu : Form, ILocalizable
    {
        private Form currentFormChild;
        public FormMenu()
        {
            InitializeComponent();
            lblUserName.Text = UserSession.FullName;
            lblPosition.Text = UserSession.Position;
            LanguageManager.LoadLanguage("en");
            ApplyLanguage();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            openChildForm(new FormDashboard());
        }

        public void ApplyLanguage()
        {
            btnHome.Text = LanguageManager.Translate("menu_home");
            btnAddChecklist.Text = LanguageManager.Translate("menu_addChecklist");
            btnChecklist.Text = LanguageManager.Translate("menu_checklist");
            btnBoard.Text = LanguageManager.Translate("menu_board");
            btnReport.Text = LanguageManager.Translate("menu_report");
            btnUser.Text = LanguageManager.Translate("menu_user");
            btnDepartment.Text = LanguageManager.Translate("menu_department");
            btnEmployee.Text = LanguageManager.Translate("menu_employee");
            btnLogout.Text = LanguageManager.Translate("menu_logout");
            btnChangePassword.Text = LanguageManager.Translate("menu_changePassword");
            btnExit.Text = LanguageManager.Translate("button_exit");
            btnSavePassword.Text = LanguageManager.Translate("button_save");
            btnDashboard.Text = LanguageManager.Translate("menu_dashboard");
            lblTitle.Text = LanguageManager.Translate("change_password");

            //txtCurrentPassword.PlaceholderText = LanguageManager.Translate("placeholder_current_password");
            //txtNewPassword.PlaceholderText = LanguageManager.Translate("placeholder_new_password");
            //txtVerifyPassword.PlaceholderText = LanguageManager.Translate("placeholder_verify_password");

            setUpPlaceHolder(txtCurrentPassword, LanguageManager.Translate("placeholder_current_password"));
            setUpPlaceHolder(txtNewPassword, LanguageManager.Translate("placeholder_new_password"));
            setUpPlaceHolder(txtVerifyPassword, LanguageManager.Translate("placeholder_verify_password"));
        }

        private void setUpPlaceHolder(Guna.UI2.WinForms.Guna2TextBox textBox, string placeholder)
        {
            textBox.PlaceholderText = placeholder; // Sử dụng thuộc tính PlaceholderText trực tiếp
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void LanguageSelect_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedLanguage = cmbLanguage.SelectedItem.ToString();
            string languageCode = selectedLanguage == "Tiếng Việt" ? "vi" : "en";

            LanguageManager.LoadLanguage(languageCode);

            ApplyLanguage();

            if (currentFormChild is ILocalizable localizableChild)
            {
                localizableChild.ApplyLanguage();
            }

            foreach (Form form in Application.OpenForms)
            {
                if (form is ILocalizable localizableForm)
                {
                    localizableForm.ApplyLanguage();
                }
            }

            Properties.Settings.Default.Language = languageCode;
            Properties.Settings.Default.Save();

            if (selectedLanguage == "Tiếng Việt")
            {
                MessageBox.Show($"Ngôn ngữ đã chuyển sang {selectedLanguage}");
            }
            else
            {
                MessageBox.Show($"Language has been switched to {selectedLanguage}");
            }
        }

        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;

            if (childForm is ILocalizable localizableForm)
            {
                localizableForm.ApplyLanguage(); 
            }

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlBody3.Controls.Add(childForm);
            pnlBody3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void SetButtonHoverEffect(Guna.UI2.WinForms.Guna2Button activeButton, Image activeImage)
        {
            foreach (Control control in pnlBody6.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button btn)
                {
                    btn.FillColor = Color.FromArgb(3, 76, 172);
                    btn.ForeColor = Color.White;

                    if (btn == btnHome)
                        btn.Image = Properties.Resources.icons8_home_100__1_;
                    else if (btn == btnAddChecklist)
                        btn.Image = Properties.Resources.icons8_add_90;
                    else if (btn == btnChecklist)
                        btn.Image = Properties.Resources.icons8_edit_property_100__1_;
                    else if (btn == btnBoard)
                        btn.Image = Properties.Resources.icons8_bar_100;
                    else if (btn == btnReport)
                        btn.Image = Properties.Resources.icons8_clipboard_100;
                }
            }
            activeButton.FillColor = Color.White;
            activeButton.ForeColor = Color.FromArgb(3, 76, 172);
            activeButton.Image = activeImage;
        }

        private void SetButtonTextColor(Guna.UI2.WinForms.Guna2Button activeButton)
        {
            // Đặt màu chữ đen cho tất cả các nút
            foreach (Control control in pnlBody2.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2Button btn &&
                    (btn == btnDashboard || btn == btnDepartment || btn == btnUser || btn == btnEmployee))
                {
                    btn.ForeColor = Color.Black; // Màu chữ đen cho các nút không được chọn
                }
            }
            // Đặt màu chữ xanh cho nút đang chọn
            activeButton.ForeColor = Color.FromArgb(3, 76, 172); // Màu xanh
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            openChildForm(new FormEmployee());
            SetButtonTextColor(btnEmployee);
        }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            pnlBody5.Visible = !pnlBody5.Visible;
            if (pnlBody5.Visible)
            {
                pnlBody5.BringToFront();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            pnlBody4.Visible = !pnlBody4.Visible;
            if (pnlBody4.Visible)
            {
                pnlBody4.BringToFront();
            }
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string userId = UserSession.UserID; // Thay bằng ID người dùng hiện tại
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string verifyPassword = txtVerifyPassword.Text;

            // Kiểm tra mật khẩu hiện tại
            if (currentPassword != UserSession.UserPassword)
            {
                MessageBox.Show("The current password does not match.");
                return;
            }

            // Kiểm tra mật khẩu theo quy chuẩn
            var (isValid, errorMessage) = IsValidPassword(newPassword);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }


            // Kiểm tra nếu mật khẩu mới và xác nhận mật khẩu trùng khớp
            if (newPassword != verifyPassword)
            {
                MessageBox.Show("The new password and confirmation password do not match.");
                return;
            }
            string connectionString = Program.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryUpdatePassword = "UPDATE [User] SET Password = @NewPassword WHERE UserID = @UserID";
                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdatePassword, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@UserID", userId);
                    cmdUpdate.Parameters.AddWithValue("@NewPassword", newPassword);

                    int rowsAffected = cmdUpdate.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("The password has been successfully updated.");
                        pnlBody4.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Password update failed.");
                    }
                }
            }
        }
        private Tuple<bool, string> IsValidPassword(string password)
        {
            // Kiểm tra độ dài mật khẩu
            if (password.Length < 8)
                return Tuple.Create(false, "The password must be at least 8 characters.");

            // Kiểm tra có chứa ít nhất một chữ hoa
            if (!Regex.IsMatch(password, "[A-Z]"))
                return Tuple.Create(false, "The password must contain at least one uppercase letter.");

            // Kiểm tra có chứa ít nhất một chữ thường
            if (!Regex.IsMatch(password, "[a-z]"))
                return Tuple.Create(false, "The password must contain at least one lowercase letter.");

            // Kiểm tra có chứa ít nhất một chữ số
            if (!Regex.IsMatch(password, "[0-9]"))
                return Tuple.Create(false, "The password must contain at least one digit.");

            // Nếu đạt tất cả các tiêu chí, mật khẩu hợp lệ
            return Tuple.Create(true, "Valid password.");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is under development.");

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is under development.");

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại với câu hỏi và hai nút "Yes" và "No"
            DialogResult result = MessageBox.Show(
                "You are being redirected to a webpage containing the app's user guide. Do you want to proceed?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            // Kiểm tra nếu người dùng chọn "Yes"
            if (result == DialogResult.Yes)
            {
                // Mở đường dẫn đến trang web
                System.Diagnostics.Process.Start("https://docs.google.com/document/d/1Dw73ajnmxDQ7EPIxXs48GCLoMoYlUHc9uDw-9zFEBqk/edit?tab=t.0");
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsDirector)
            {
                MessageBox.Show("Chức năng này chỉ dành cho Giám đốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            openChildForm(new FormUser());
            SetButtonTextColor(btnUser);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            if (!UserSession.IsDirector)
            {
                MessageBox.Show("Chức năng này chỉ dành cho Giám đốc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            openChildForm(new FormDepartment());
            SetButtonTextColor(btnDepartment);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetButtonTextColor(btnDashboard);
            openChildForm(new FormHome());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openChildForm(new FormHome());
            SetButtonTextColor(btnDashboard);
            SetButtonHoverEffect(btnHome, Properties.Resources.icons8_home_100__2_);
        }

        private void btnAddChecklist_Click(object sender, EventArgs e)
        {
            openChildForm(new FormAddChecklist());
            SetButtonTextColor(btnDashboard);
            SetButtonHoverEffect(btnAddChecklist, Properties.Resources.icons8_add_90__1_);
        }

        private void btnMenu_Expand_Click(object sender, EventArgs e)
        {
            btnMenu_Collapse.Visible = true;
            btnMenu_Expand.Visible = false;
            pnlBody6.Visible = false;
            pnlBody6.Width = 80;
            transition.ShowSync(pnlBody6);
        }

        private void btnMenu_Collapse_Click(object sender, EventArgs e)
        {
            btnMenu_Collapse.Visible = false;
            btnMenu_Expand.Visible = true;
            pnlBody6.Visible = false;
            pnlBody6.Width = 250;
            transition.ShowSync(pnlBody6);
        }

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            openChildForm(new FormChecklist());
            SetButtonTextColor(btnDashboard);
            SetButtonHoverEffect(btnChecklist, Properties.Resources.icons8_edit_property_100);
        }

        private void btnBoard_Click(object sender, EventArgs e)
        {
            openChildForm(new FormBoard());
            SetButtonTextColor(btnDashboard);
            SetButtonHoverEffect(btnBoard, Properties.Resources.icons8_bar_100__1_);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            openChildForm(new FormReport());
            SetButtonTextColor(btnDashboard);
            SetButtonHoverEffect(btnReport, Properties.Resources.icons8_clipboard_100__1_);
        }

        private void btnChangePassword_Click_1(object sender, EventArgs e)
        {
            pnlBody4.Visible = !pnlBody4.Visible;
            if (pnlBody4.Visible)
            {
                pnlBody4.BringToFront();
            }
        }

        private void btnSavePassword_Click_1(object sender, EventArgs e)
        {
            string userId = UserSession.UserID; // Thay bằng ID người dùng hiện tại
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string verifyPassword = txtVerifyPassword.Text;
            //MessageBox.Show(UserSession.UserPassword);

            // Kiểm tra mật khẩu hiện tại
            if (currentPassword != UserSession.UserPassword)
            {
                MessageBox.Show("The current password does not match.");
                return;
            }

            // Kiểm tra mật khẩu theo quy chuẩn
            var (isValid, errorMessage) = IsValidPassword(newPassword);
            if (!isValid)
            {
                MessageBox.Show(errorMessage);
                return;
            }


            // Kiểm tra nếu mật khẩu mới và xác nhận mật khẩu trùng khớp
            if (newPassword != verifyPassword)
            {
                MessageBox.Show("The new password and confirmation password do not match.");
                return;
            }
            string connectionString = Program.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string queryUpdatePassword = "UPDATE [User] SET Password = @NewPassword WHERE UserID = @UserID";
                using (SqlCommand cmdUpdate = new SqlCommand(queryUpdatePassword, connection))
                {
                    cmdUpdate.Parameters.AddWithValue("@UserID", userId);
                    cmdUpdate.Parameters.AddWithValue("@NewPassword", newPassword);

                    int rowsAffected = cmdUpdate.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("The password has been successfully updated.");
                        pnlBody4.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Password update failed.");
                    }
                }
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin login = new FormLogin();
            login.ShowDialog();
        }

        private void pnlInfoUser_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (pnlBody5.Visible)
            {
                pnlBody5.Visible = false;
            }
            if (pnlBody4.Visible)
            {
                pnlBody4.Visible = false;
            }
        }

        private void lblChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            openChildForm(new FormInformation());
        }
    }
}
