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

        private void menuMasterMembers_Click(object sender, EventArgs e)
        {

        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            var bookingForm = serviceProvider.GetRequiredService<frmBooking>();
            OpenChild(bookingForm);
        }

        private void incomeExpensesFundTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void carCardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TestDataConnection()
        {
            //var xx = repository.GetAll();

            // HotelDB connection test
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotelDb;Persist Security Info=True;User ID=sa;Password=vijuma;Trust Server Certificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();

                conn.Open();
                adapter.Fill(table);

                var count = table.Rows.Count;

            }
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
    }
}
