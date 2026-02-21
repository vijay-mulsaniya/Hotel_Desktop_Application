using Hotel.Common;
using Hotel.Data;
using Hotel.Dtos;
using Hotel.Models;
using Hotel.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hotel.Forms
{
    public partial class frmBookNow : Form
    {
        private readonly IRepository<TblRoomBooking> roomRepository;
        private readonly IRepository<TblRoom> repository;
        private readonly IRoomService roomService;
        private readonly AppDbContext context;
        private readonly frmPayment _payment;
        List<TblRoomBooking> roomBookings = new List<TblRoomBooking>();
        BindingList<TblRoomBooking> bookingGridSource = new BindingList<TblRoomBooking>();
        List<ListboxItemAvailableRooms> availableRooms = new List<ListboxItemAvailableRooms>();
        private static int HotelID = 1; // Assuming hotel ID is 1 for this example;
        private static string HotelStateCode = "GJ";
        private static string GuestStateCode = "GJ";

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRoomId { get; set; } = -1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedCheckInDate { get; set; } = DateTime.UtcNow.GetIndianTime();

        public frmBookNow(IRepository<TblRoomBooking> roomRepository,
            IRepository<TblRoom> repository,
            IRoomService roomService,
            AppDbContext context, frmPayment payment)
        {
            InitializeComponent();
            dtpFromDateTime.Format = DateTimePickerFormat.Custom;
            dtpFromDateTime.CustomFormat = "dd/MM/yyyy hh:mm tt";

            dtpToDateTime.Format = DateTimePickerFormat.Custom;
            dtpToDateTime.CustomFormat = "dd/MM/yyyy hh:mm tt";

            this.roomRepository = roomRepository;
            this.repository = repository;
            this.roomService = roomService;
            this.context = context;
            _payment = payment;
        }
        private void frmBookNow_Load(object sender, EventArgs e)
        {
            gvBooking.AutoGenerateColumns = false;
            AddRoomBookingColumns();
            gvBooking.RowHeadersVisible = false;
            gvBooking.DataSource = bookingGridSource;

            ResetFromToDate();
            availableRooms = GetAvailableRooms();

            var guests = Guests();
            cmbGuests.DataSource = guests;
            cmbGuests.DisplayMember = "DisplayName";
            cmbGuests.ValueMember = "ID";
            cmbGuests.SelectedIndex = -1;

            btnAddToGrid.Enabled = false;
            btnSave.Enabled = false;
            dtpFromDateTime.Focus();
            grpBox.Enabled = false;

            listBox1.SelectedValue = SelectedRoomId;
        }

        private void ResetFromToDate()
        {
            var now = SelectedCheckInDate;

            dtpFromDateTime.Value = now;
            dtpToDateTime.MinDate = dtpFromDateTime.Value.AddHours(1); // Minimum checkout time is 1 hour after check-in
            dtpToDateTime.Value = now.Date.AddDays(1).AddHours(8).AddMinutes(30);
            dtpToDateTime.ValueChanged += (s, e) =>
            {
                if (dtpToDateTime.Value <= dtpFromDateTime.Value)
                {
                    MessageBox.Show("Checkout time must be after check-in time.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpToDateTime.Value = dtpFromDateTime.Value.AddHours(1);
                }
            };
        }

        private void AddRoomBookingColumns()
        {
            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Visible = false
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "HotelID",
                HeaderText = "HotelID",
                Visible = false
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BookingMasterID",
                HeaderText = "BookingMasterID",
                Visible = false
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "GuestID",
                HeaderText = "GuestID",
                Visible = false
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RoomID",
                HeaderText = "RoomID",
                Visible = false
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RoomNumber",
                HeaderText = "Room Number",
                Width = 250
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Date",
                HeaderText = "Date"
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NightStay",
                HeaderText = "Night Stay"
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AdultCount",
                HeaderText = "Adult Count"
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ChildCount",
                HeaderText = "Child Count"
            });

            gvBooking.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Amount",
                HeaderText = "Amount",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C0" }
            });
        }

        private List<GuestComboBoxItem> Guests()
        {
            return context.Guests.Where(g => g.HotelID == HotelID)
                                 .OrderBy(x => x.FirstName)
                                 .Select(x => new GuestComboBoxItem
                                 {
                                     ID = x.ID,
                                     DisplayName = $"{x.FirstName} - Mo: {x.PhoneNumber}"
                                 }).ToList();

        }
        private List<ListboxItemAvailableRooms> GetAvailableRooms()
        {

            DateTime fromDate = dtpFromDateTime.Value;
            DateTime toDate = dtpToDateTime.Value; // checkout date (excluded)

            var availableRooms = context.Rooms
                .Where(r => r.HotelID == HotelID)
                .Where(r => r.IsAvailable)
                .Where(r =>
                    !r.RoomBookings.Any(rb =>
                        rb.Status == BookingStatus.Booked &&
                        rb.NightStay == true &&
                        rb.Date.HasValue &&
                        rb.Date.Value >= fromDate &&
                        rb.Date.Value < toDate
                    )
                )
                .Select(x => new ListboxItemAvailableRooms
                {
                    ID = x.ID,
                    RoomNumber = x.RoomNumber!,
                    DisplayName = $"{x.RoomNumber} - {x.RoomTitle}" + (x.RoomBookings.Any(b => b.Date.HasValue && b.Date.Value.Date == fromDate.Date && b.NightStay == false) ? " ✔" : ""),
                    IsCheckoutToday = x.RoomBookings.Any(b => b.NightStay == false)
                })
                .ToList();

            listBox1.DataSource = null;
            listBox1.DataSource = availableRooms;
            listBox1.DisplayMember = "DisplayName";
            listBox1.ValueMember = "ID";
            listBox1.SelectedIndex = -1;
            
            return availableRooms;
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            GetAvailableRooms();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                grpBox.Enabled = false;
                btnAddToGrid.Enabled = false;
                btnSave.Enabled = false;
                lblSelectedRooms.Text = "No Rooms selected";
                return;
            }

            // Join all selected items into a single string
            lblSelectedRooms.Text = string.Join(", ",
                listBox1.SelectedItems.Cast<ListboxItemAvailableRooms>().Select(item => item.RoomNumber!.ToString()));

            btnAddToGrid.Enabled = true;
            grpBox.Enabled = true;
        }

        private void btnAddToGrid_Click(object sender, EventArgs e)
        {
            btnAddToGrid.Enabled = false; // Disable the button to prevent multiple clicks
            foreach (var selectedRoom in listBox1.SelectedItems.Cast<ListboxItemAvailableRooms>())
            {
                DateTime fromDate = dtpFromDateTime.Value;
                DateTime toDate = dtpToDateTime.Value;
                var selectedGuest = cmbGuests.SelectedItem as GuestComboBoxItem;
                var guestId = selectedGuest != null ? selectedGuest.ID : 0; // Get selected guest ID

                for (DateTime date = fromDate; date.Date < toDate.Date; date = date.AddDays(1))
                {
                    bookingGridSource.Add(new TblRoomBooking
                    {
                        ID = 0, // This would be set when saving to the database
                        HotelID = HotelID,
                        BookingMasterID = 0, // This would be set when saving to the database
                        GuestID = guestId,
                        RoomID = selectedRoom.ID,
                        Status = BookingStatus.Booked,
                        Date = date,
                        NightStay = true, // Each entry represents one night stay
                        AdultCount = Convert.ToInt32(txtAdult.Text),
                        ChildCount = Convert.ToInt32(txtChild.Text),
                        Amount = Convert.ToDecimal(txtPricePerNight.Text) // Assuming price per night is a property of TblRoom
                    });
                }

                bookingGridSource.Add(new TblRoomBooking
                {
                    ID = 0,
                    HotelID = HotelID,
                    BookingMasterID = 0,
                    GuestID = guestId,
                    RoomID = selectedRoom.ID,
                    Status = BookingStatus.Booked,
                    Date = toDate,
                    NightStay = false, //Last entry for checkout day
                    AdultCount = Convert.ToInt32(txtAdult.Text),
                    ChildCount = Convert.ToInt32(txtChild.Text),
                    Amount = 0
                });

            }

            CalculateTotals();
            btnSave.Enabled = true;
        }

        private void CalculateTotals()
        {
            var totalAmount = bookingGridSource.Sum(x => x.Amount);
            decimal discount = txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0;
            decimal sGST = 0;
            decimal cGST = 0;
            decimal iGST = 0;
            decimal finalAmount = totalAmount - discount + sGST + cGST + iGST;

            lblTotalAmount.Text = totalAmount.ToString("C0");
            lblTotal.Text = (totalAmount - discount).ToString("C0");
            lblSGST.Text = sGST.ToString("C0");
            lblCGST.Text = cGST.ToString("C0");
            lblIGST.Text = iGST.ToString("C0");
            lblFinalTotal.Text = finalAmount.ToString("C0");
        }
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            CalculateTotals();
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false; // Disable the button to prevent multiple clicks

            int currentNumber = 0;
            TblTransactionSequence? transactionSequence;
            string invoiceNumber;
            var currentDate = DateTime.UtcNow.GetIndianTime();
            roomService.GenerateInvoiceNumber(HotelID, out currentNumber, out transactionSequence, out invoiceNumber);

            transactionSequence!.LastNumber = currentNumber;
            await roomService.AddNewBooking(new AddNewBookingDto
            {
                BookingMaster = new TblBookingMaster
                {
                    ID = 0,
                    HotelID = HotelID,
                    InvoiceNumber = invoiceNumber,
                    InvoiceDate = currentDate,
                    GuestID = (int)cmbGuests.SelectedValue!,
                    CheckInDate = dtpFromDateTime.Value,
                    CheckOutDate = dtpToDateTime.Value,
                    Discount = txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0,
                    InputTaxCredit = false,
                    HotelStateCode = HotelStateCode,
                    GuestStateCode = GuestStateCode,
                    IsGSTApplicable = false,
                    IsTaxInclusive = false,
                    CreatedOn = currentDate,
                    IsActive = true,
                    IsDeleted = false
                },
                RoomBookings = bookingGridSource.ToList()
            });

            clearForm();
            DialogResult result = MessageBox.Show(
                                    "Booking saved successfully!\n\nWould you like to collect payment now?",
                                    "Success",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _payment.MdiParent = this.MdiParent;
                this.Close();
                _payment.Show();
            }

        }

        private void clearForm()
        {
            txtDiscount.Text = "0";

            bookingGridSource.Clear();
            CalculateTotals();
            ResetFromToDate();
            GetAvailableRooms();

            listBox1.SelectedIndex = -1;
            cmbGuests.SelectedIndex = -1;
            txtAdult.Text = "";
            txtChild.Text = "";
            txtPricePerNight.Text = "";

            btnAddToGrid.Enabled = false;
            btnSave.Enabled = false;
            dtpFromDateTime.Focus();
        }

        private void gvBooking_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                var row = gvBooking.Rows[e.RowIndex + i];
                var booking = row.DataBoundItem as TblRoomBooking;

                if (booking == null) continue;

                // Find the selected room
                var room = availableRooms.FirstOrDefault(r => r.ID == booking.RoomID);

                if (room != null)
                {
                    row.Cells["RoomNumber"].Value = room.DisplayName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void dtpFromDateTime_Leave(object sender, EventArgs e)
        {
            var now = dtpFromDateTime.Value;
            dtpToDateTime.MinDate = dtpFromDateTime.Value.AddHours(1);
            dtpToDateTime.Value = now.Date.AddDays(1).AddHours(8).AddMinutes(30);
        }

        private void txtPricePerNight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPricePerNight_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPricePerNight.Text))
            {
                txtPricePerNight.Text = "0";
                return;
            }

            if (!int.TryParse(txtPricePerNight.Text, out int value))
            {
                MessageBox.Show("Please enter a valid number.");
                e.Cancel = true;
                return;
            }

            if (value < 0 || value > 8000)
            {
                MessageBox.Show("Value must be between 0 and 8000.");
                e.Cancel = true;
                txtPricePerNight.SelectAll();
            }
        }

        private void txtAdult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAdult_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtAdult.Text, out int value))
            {
                txtAdult.Text = Math.Clamp(value, 0, 8).ToString();
            }
            else
            {
                txtAdult.Text = "0";
            }
        }

        private void txtChild_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtChild_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtChild.Text, out int value))
            {
                txtChild.Text = Math.Clamp(value, 0, 8).ToString();
            }
            else
            {
                txtChild.Text = "0";
            }
        }
    }

    public class GuestComboBoxItem
    {
        public int ID { get; set; }
        public string DisplayName { get; set; } = null!;
    }

    public class ListboxItemAvailableRooms
    {
        public int ID {  set; get; }
        public string RoomNumber { set; get; } = null!;
        public string DisplayName { get; set; } = string.Empty;
        public bool IsCheckoutToday { get; set; }
    }
}
