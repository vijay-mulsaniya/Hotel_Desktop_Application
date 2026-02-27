using Hotel.Common;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hotel.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private async Task<bool> AuthenticateUser(string username, string password)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = await context.Users
                        .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role)
                        .FirstOrDefaultAsync(u => u.UserName == username && u.IsActive == true);

                    if (user == null)
                        return false;

                    if (user.PasswordHash != password) //PasswordHasher.VerifyPassword(password, user.PasswordHash) will use letter...
                        return false;
                    
                    AppSession.CurrentUser = user;
                    AppSession.Roles = user.UserRoles.Select(ur => ur.Role!.RoleName).ToList();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false; // prevent double click

            var result = await AuthenticateUser(
                txtUserName.Text.Trim(),
                txtPassword.Text);

            if (result)
            {
                this.DialogResult = DialogResult.OK; // ✅ close only on success
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Invalid Username or Password!",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Clear();
                txtPassword.Focus();
            }

            btnlogin.Enabled = true;
        }
    }
}
