using Hotel.Common;
using Hotel.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.ComponentModel;

namespace Hotel.Forms
{
    public partial class FrmRoomBookingEdit : Form
    {
        private RoomBookingDto _booking = new RoomBookingDto();
        private string _connectionString;
        private List<(int ID, string? RoomNumber, string? RoomTitle)> roomList = [];
        private List<(int ID, string? RoomNumber, string? RoomTitle)> roomListFromToDate = [];

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RoomBookingDto BookingData
        {
            get => _booking;
            set
            {
                _booking = value;
            }
        }

        public FrmRoomBookingEdit()
        {
            InitializeComponent();
            //_booking = booking;
            _connectionString = CommonMethods.GetConnectionString();
            cmbRoomNumbers.SelectedIndexChanged += CheckForChanges;
            dtpDate.ValueChanged += CheckForChanges;
            chkNightStay.CheckedChanged += CheckForChanges;
            txtAdultCount.TextChanged += CheckForChanges;
            txtChildCount.TextChanged += CheckForChanges;
            txtAmount.TextChanged += CheckForChanges;
        }

        private void FrmRoomBookingEdit_Load(object sender, EventArgs e)
        {
            roomList = GetAvailableRooms(_booking.RoomID);

            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy hh:mm tt";

            dtpFromDate.Format = DateTimePickerFormat.Custom;
            dtpFromDate.CustomFormat = "dd/MM/yyyy hh:mm tt";

            dtpToDate.Format = DateTimePickerFormat.Custom;
            dtpToDate.CustomFormat = "dd/MM/yyyy hh:mm tt";

            var roomSource = roomList.Select(r => new
            {
                r.ID,
                DisplayName = $"{r.RoomNumber} - {r.RoomTitle}"
            }).ToList();

            cmbRoomNumbers.DataSource = roomSource;
            cmbRoomNumbers.ValueMember = "ID";
            cmbRoomNumbers.DisplayMember = "DisplayName";
            cmbRoomNumbers.SelectedValue = _booking.RoomID;
            cmbRoomNumbers.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbRoomNumbers.AutoCompleteSource = AutoCompleteSource.ListItems;


            lblGuestName.Text = _booking.GuestName;
            dtpDate.Value = _booking.Date!.Value;

            if (_booking.NightStay == true)
            {
                chkNightStay.Checked = true;
                chkNightStay.Text = "Yes";
            }
            else
            {
                chkNightStay.Checked = false;
                chkNightStay.Text = "No";
            }

            txtAdultCount.Text = _booking.AdultCount.ToString();
            txtChildCount.Text = _booking.ChildCount.ToString();
            txtAmount.Text = _booking.Amount.ToString();

            btnSave.Enabled = false;

            ResetFromToDate();
        }

        private void FillRoomsByDate()
        {

            var roomSource = roomListFromToDate.Select(r => new
            {
                r.ID,
                DisplayName = $"{r.RoomNumber} - {r.RoomTitle}"
            }).ToList();

            cmbRoomNumbersExtend.DataSource = null;
            cmbRoomNumbersExtend.DataSource = roomSource;
            cmbRoomNumbersExtend.ValueMember = "ID";
            cmbRoomNumbersExtend.DisplayMember = "DisplayName";
            cmbRoomNumbersExtend.SelectedValue = _booking.RoomID;
            cmbRoomNumbersExtend.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbRoomNumbersExtend.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ResetFromToDate()
        {
            var now = DateTime.UtcNow.GetIndianTime();

            dtpFromDate.Value = now;
            dtpToDate.MinDate = dtpFromDate.Value.AddHours(1); // Minimum checkout time is 1 hour after check-in
            dtpToDate.Value = now.Date.AddDays(1).AddHours(8).AddMinutes(30);
            dtpToDate.ValueChanged += (s, e) =>
            {
                if (dtpToDate.Value <= dtpFromDate.Value)
                {
                    MessageBox.Show("Checkout time must be after check-in time.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpToDate.Value = dtpFromDate.Value.AddHours(1);
                }
            };

            roomListFromToDate = GetAvailableRoomsBySelectedDates(dtpFromDate, dtpToDate);
            FillRoomsByDate();
        }

        private void CheckForChanges(object? sender, EventArgs e)
        {
            if (_booking == null) return;

            // 1. Handle the ComboBox Safely
            var selectedRoomId = (cmbRoomNumbers.SelectedItem as dynamic)?.ID;

            // 2. Parse Numeric Strings to avoid "100" vs "100.00" mismatches
            int.TryParse(txtAdultCount.Text, out int currentAdults);
            int.TryParse(txtChildCount.Text, out int currentChildren);
            decimal.TryParse(txtAmount.Text, out decimal currentAmount);

            // 3. The Comparison Logic
            bool isChanged =
                selectedRoomId != _booking.RoomID ||
                dtpDate.Value != _booking.Date ||
                chkNightStay.Checked != _booking.NightStay ||
                currentAdults != _booking.AdultCount ||
                currentChildren != _booking.ChildCount ||
                currentAmount != _booking.Amount;

            btnSave.Enabled = isChanged;
        }

        private List<(int ID, string? RoomNumber, string? RoomTitle)> GetAvailableRooms(int ID)
        {
            string query = @"SELECT distinct 
                                R.ID, 
                                R.RoomNumber, 
                                R.RoomTitle
                            FROM Rooms R
                            LEFT JOIN RoomBookings RB 
                                ON R.ID = RB.RoomID 
                                AND CAST(RB.Date AS DATE) = @date
                            WHERE RB.RoomID IS NULL OR R.ID = @ID;"; //

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@date", dtpDate.Value.Date);
            cmd.Parameters.AddWithValue("@ID", ID);
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                var result = dataSet.Tables[0].AsEnumerable().Select(row => (
                             ID: row.Field<int>("ID"),
                             RoomNumber: row.Field<string?>("RoomNumber"),
                             RoomTitle: row.Field<string?>("RoomTitle") // Fixed to string
                         )).ToList();

                return result;

            }
            ;
        }

        private List<(int ID, string? RoomNumber, string? RoomTitle)> GetAvailableRoomsBySelectedDates(DateTimePicker fromDate, DateTimePicker toDate)
        {
            string query = @"select R.ID, R.RoomNumber, R.RoomTitle
                                    from Rooms R
                                    Where R.ID Not In
                                    (
	                                    select RoomID from RoomBookings where Date Between @fromDate and @toDate
                                    );";

            SqlConnection con = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fromDate", fromDate.Value);
            cmd.Parameters.AddWithValue("@toDate", toDate.Value);

            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                var result = dataSet.Tables[0].AsEnumerable().Select(row => (
                             ID: row.Field<int>("ID"),
                             RoomNumber: row.Field<string?>("RoomNumber"),
                             RoomTitle: row.Field<string?>("RoomTitle") // Fixed to string
                         )).ToList();

                return result;
            }
            ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = @"
                UPDATE RoomBookings SET 
                    RoomID = @RoomID,
                    GuestId = @GuestID,
                    Status = @Status,
                    Date = @Date,
                    NightStay = @NightStay,
                    AdultCount = @AdultCount,
                    ChildCount = @ChildCount,
                    Amount = @Amount
                WHERE ID = @ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@RoomID", cmbRoomNumbers.SelectedValue);
                cmd.Parameters.AddWithValue("@GuestID", _booking.GuestID);
                cmd.Parameters.AddWithValue("@Status", 1);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                cmd.Parameters.AddWithValue("@NightStay", chkNightStay.Checked);
                cmd.Parameters.AddWithValue("@AdultCount", txtAdultCount.Text);
                cmd.Parameters.AddWithValue("@ChildCount", txtChildCount.Text);
                cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                cmd.Parameters.AddWithValue("@ID", _booking.ID);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Save Successfully", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void chkNightStay_CheckedChanged(object sender, EventArgs e)
        {
            var nightChecked = chkNightStay.Checked ? "Yes" : "No";
            chkNightStay.Text = nightChecked;
            if (chkNightStay.Checked == false)
            {
                txtAmount.Text = "0.00";
                txtAmount.Enabled = false;
            }
            else
            {
                txtAmount.Text = _booking.Amount.ToString();
                txtAmount.Enabled = true;
            }
        }

        private void btnAddNewDates_Click(object sender, EventArgs e)
        {
            var fromDate = dtpFromDate.Value;
            var toDate = dtpToDate.Value;

            var isValid = validaeBulkBookingSave();

            if (!isValid)
            {
                MessageBox.Show("Please select all required fields", "All fields not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            for (DateTime date = fromDate; date.Date < toDate.Date; date = date.AddDays(1))
            {
                string query = @"Insert into RoomBookings(HotelID, BookingMasterID, RoomID, GuestID, Date, NightStay, AdultCount, ChildCount, Amount, Status, IsActive, IsDeleted, CreatedOn)
                               values (@HotelID, @BookingMasterID, @RoomID, @GuestID, @Date, @NightStay, @AdultCount, @ChildCount, @Amount, @Status, @IsActive, @IsDeleted, @CreatedOn);";

                using (SqlConnection con = new SqlConnection(_connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@HotelID", 1);
                    cmd.Parameters.AddWithValue("@BookingMasterID", _booking.BookingMasterID);
                    cmd.Parameters.AddWithValue("@RoomID", cmbRoomNumbersExtend.SelectedValue);
                    cmd.Parameters.AddWithValue("@GuestID", _booking.GuestID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@NightStay", true);
                    cmd.Parameters.AddWithValue("@Status", 1);
                    cmd.Parameters.AddWithValue("@AdultCount", txtAdultsExtend.Text);
                    cmd.Parameters.AddWithValue("@ChildCount", txtChildExtend.Text);
                    cmd.Parameters.AddWithValue("@Amount", txtPerNightCharge.Text);
                    cmd.Parameters.AddWithValue("@IsActive", true);
                    cmd.Parameters.AddWithValue("@IsDeleted", false);
                    cmd.Parameters.AddWithValue("@CreatedOn", DateTime.UtcNow.GetIndianTime());

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            //string query2 = @"Insert into RoomBookings(HotelID, BookingMasterID, RoomID, GuestID, Date, NightStay, AdultCount, ChildCount, Amount, Status, IsActive, IsDeleted, CreatedOn)
            //                   values (@HotelID, @BookingMasterID, @RoomID, @GuestID, @Date, @NightStay, @AdultCount, @ChildCount, @Amount, @Status, @IsActive, @IsDeleted, @CreatedOn);";

            //using (SqlConnection con = new SqlConnection(_connectionString))
            //using (SqlCommand cmd = new SqlCommand(query2, con))
            //{
            //    cmd.Parameters.AddWithValue("@HotelID", 1);
            //    cmd.Parameters.AddWithValue("@BookingMasterID", _booking.BookingMasterID);
            //    cmd.Parameters.AddWithValue("@RoomID", cmbRoomNumbersExtend.SelectedValue);
            //    cmd.Parameters.AddWithValue("@GuestID", _booking.GuestID);
            //    cmd.Parameters.AddWithValue("@Date", dtpToDate.Value);
            //    cmd.Parameters.AddWithValue("@NightStay", false);
            //    cmd.Parameters.AddWithValue("@Status", 1);
            //    cmd.Parameters.AddWithValue("@AdultCount", txtAdultsExtend.Text);
            //    cmd.Parameters.AddWithValue("@ChildCount", txtChildExtend.Text);
            //    cmd.Parameters.AddWithValue("@Amount", 0);
            //    cmd.Parameters.AddWithValue("@IsActive", true);
            //    cmd.Parameters.AddWithValue("@IsDeleted", false);
            //    cmd.Parameters.AddWithValue("@CreatedOn", DateTime.UtcNow.GetIndianTime());

            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}

            MessageBox.Show("Save Successfully", "Success",
               MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dtpFromDate_Leave(object sender, EventArgs e)
        {
            var now = dtpFromDate.Value;
            dtpToDate.MinDate = dtpFromDate.Value.AddHours(1);
            dtpToDate.Value = now.Date.AddDays(1).AddHours(8).AddMinutes(30);

            roomListFromToDate = GetAvailableRoomsBySelectedDates(dtpFromDate, dtpToDate);
            FillRoomsByDate();
        }

        private bool validaeBulkBookingSave()
        {
            if (cmbRoomNumbersExtend.SelectedIndex == -1) return false;
            if (txtAdultsExtend.Text == "") return false;
            if (txtChildExtend.Text == "") return false;
            if (txtPerNightCharge.Text == "") return false;

            return true;
        }

        private void txtPerNightCharge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAdultCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChildCount_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtChildCount.Text, out int value))
            {
                txtChildCount.Text = Math.Clamp(value, 0, 8).ToString();
            }
            else
            {
                txtChildCount.Text = "0";
            }
        }

        private void dtpToDate_Leave(object sender, EventArgs e)
        {
            roomListFromToDate = GetAvailableRoomsBySelectedDates(dtpFromDate, dtpToDate);
            FillRoomsByDate();
        }
    }
}
