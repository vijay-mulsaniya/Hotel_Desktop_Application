using Hotel.Common;
using Hotel.Data;
using Hotel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml.Drawing.Style.Coloring;
using System.Data;
using System.Windows.Forms;


namespace Hotel.Forms
{
    public partial class MainForm : Form
    {

        private readonly IServiceProvider serviceProvider;
        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            SetMdiClientBackgroundColor(ColorTranslator.FromHtml("#00bff3"));
        }
        private void SetMdiClientBackgroundColor(System.Drawing.Color color)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient mdiClient)
                {
                    mdiClient.BackColor = color;
                    break; // Exit the loop once the MdiClient control is found and modified
                }
            }
        }
        private void OpenChild(Form childForm)
        {
            foreach (Form f in MdiChildren)
                f.Close();

            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            EnableMenus(true);
            ApplyPermissions();
        }
        private void ApplyPermissions()
        {
            btnBookNow.Visible = AppSession.IsInRole("Admin");
            btnReports.Visible = AppSession.IsInRole("Admin");
            btnChangePassword.Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager");
            btnHistory.Visible = AppSession.IsInRole("Admin") || AppSession.IsInRole("Manager");
            statusLabelUserName.Text = $"Welcome, {AppSession.CurrentUser?.UserName}!";
        }

        private void EnableMenus(bool enable)
        {
            mainMenu.Enabled = enable;
            mainToolStrip.Enabled = enable;
        }

        private void menuFileLogout_Click(object sender, EventArgs e)
        {

            Application.Restart();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            var bookingForm = serviceProvider.GetRequiredService<frmBooking>();
            OpenChild(bookingForm);
        }
       
        private void btnReceipt_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<FrmDateWiseRoomView>();
            OpenChild(frm);
        }
        private void btnReports_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<frmPaymentCollectionReport>();
            OpenChild(frm);
        }
        private void btnTransactions_Click(object sender, EventArgs e)
        {
            var form = serviceProvider.GetRequiredService<frmPayment>();
            OpenChild(form);
        }
       
        private void btnBookNow_Click(object sender, EventArgs e)
        {
            var bookingForm = serviceProvider.GetRequiredService<frmBookNow>();
            OpenChild(bookingForm);
        }

        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<frmGuest>();
            OpenChild(frm);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<FrmChangePassword>();
            OpenChild(frm);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<FrmIDUpload>();
            OpenChild(frm);
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            var frm = serviceProvider.GetRequiredService<FrmAboutUs>();
            frm.ShowDialog();
            OpenChild(frm);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            var frm = new FrmActivity();
            frm.ShowDialog();
        }
    }
}
