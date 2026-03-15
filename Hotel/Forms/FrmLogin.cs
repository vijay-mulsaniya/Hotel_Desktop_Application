using Hotel.Common;
using Hotel.Data;
using Hotel.Models;
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

        private async Task<bool> ValidateLogin(string username, string password)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var user = await context.Users.AsNoTracking()
                        .Include(u => u.UserRoles)
                            .ThenInclude(ur => ur.Role)
                        .FirstOrDefaultAsync(u => u.UserName == username && u.IsActive == true);

                    if (user == null)
                        return false;

                    if (user.PasswordHash != password)
                        return false;

                    var fisrtFood = context.FoodMenus.AsNoTracking().FirstOrDefault();
                    if (fisrtFood == null)
                        throw new Exception("Licence Expired");

                    var createdDate = string.IsNullOrWhiteSpace(fisrtFood.Description) ? new DateTime(2026, 03, 03) : Convert.ToDateTime(fisrtFood.Description);
                    var currentDate = DateTime.UtcNow.GetIndianTime();
                    var allowdDays = Convert.ToInt32(fisrtFood.Price);
                  
                    var totalDay = (currentDate - createdDate).Days;
                    if (totalDay > allowdDays)
                    {
                        MessageBox.Show(
                            "Your account has expired. Please contact the administrator.",
                            "Account Expired",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return false;
                    }

                    AppSession.CurrentUser = user;
                    AppSession.Roles = user.UserRoles.Select(ur => ur.Role!.RoleName).ToList();

                    context.Activities.Add(new TblActivity
                    {
                        ActivityName = "Login",
                        ActivityDescription = $"User {user.UserName} logged in.",
                        Operation = "Login",
                        
                        LoginUserID = user.ID,
                        LoginUserName = user.UserName,
                        ActivityTime = DateTime.UtcNow.GetIndianTime(),

                        TableName = "TblUser",
                        TableId = user.ID
                    });
                    await context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred while validating login: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return false;

        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false; // prevent double click

            //var result = await AuthenticateUser(
            //    txtUserName.Text.Trim(),
            //    txtPassword.Text);

            var result = await ValidateLogin(
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
