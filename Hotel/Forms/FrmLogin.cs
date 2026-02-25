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

                    //PasswordHasher.VerifyPassword(password, user.PasswordHash) will use letter...
                    if (user != null && user.PasswordHash == password && user.UserName == username)
                    {
                        AppSession.CurrentUser = user;
                        AppSession.Roles = user.UserRoles.Select(ur => ur.Role!.RoleName).ToList();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Username or password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
           await AuthenticateUser(txtUserName.Text, txtPassword.Text);

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
