using Hotel.Common;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hotel.Forms
{
    public partial class FrmChangePassword : Form
    {
        public FrmChangePassword()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtConfirmPassword.Text != txtNewPassword.Text)
                {
                    MessageBox.Show("New password and confirm password not match.", "Invaid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtUserName.Text) ||
                    string.IsNullOrWhiteSpace(txtUserName.Text)
                    )
                {
                    MessageBox.Show("All are required fields please fill all textbox.", "Invaid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool result = await UpdatePassword(txtUserName.Text, txtOldPassword.Text, txtNewPassword.Text);

                if (result)
                {
                    MessageBox.Show("Your password has been changed.", "Password Change", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while save password change", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> UpdatePassword(string userName, string oldPassword, string newPassword)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = await context.Users
                        .FirstOrDefaultAsync(u => u.UserName == userName
                        && u.IsActive == true
                        && u.PasswordHash == oldPassword);

                    if (user == null) throw new Exception("Invalid Credentials");

                    user.PasswordHash = newPassword;
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username or password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
