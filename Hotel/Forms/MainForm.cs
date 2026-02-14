using Hotel.Data;
using Hotel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
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
            //TestDataConnection();
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
    }
}
