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
        private readonly IPaymentService paymentService;
        List<TblRoomBooking> roomBookings = new List<TblRoomBooking>();
        BindingList<TblRoomBooking> bookingGridSource = new BindingList<TblRoomBooking>();
        List<ListboxItemAvailableRooms> availableRooms = new List<ListboxItemAvailableRooms>();
        private static int HotelID = 1; // Assuming hotel ID is 1 for this example;
        private static string HotelStateCode = "GJ";
       

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRoomId { get; set; } = -1;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedCheckInDate { get; set; } = DateTime.UtcNow.GetIndianTime();

        public frmBookNow(IRepository<TblRoomBooking> roomRepository,
            IRepository<TblRoom> repository,
            IRoomService roomService,
            AppDbContext context, frmPayment payment, IPaymentService paymentService)
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
            this.paymentService = paymentService;
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

            DateTime fromDate = dtpFromDateTime.Value.Date;
            DateTime toDate = dtpToDateTime.Value.Date;
            DateTime yesterday = fromDate.AddDays(-1);

            var availableRooms = context.Rooms
                .Where(r => r.HotelID == HotelID)
                .Where(r => r.IsAvailable)
                .Where(r =>
                    !r.RoomBookings.Any(rb =>
                        rb.Status == BookingStatus.Booked &&
                        rb.NightStay == true &&
                        rb.Date.HasValue &&
                        rb.Date.Value.Date >= fromDate &&
                        rb.Date.Value.Date < toDate
                    )
                )
                .Select(x => new
                {
                    x.ID,
                    x.RoomNumber,
                    x.RoomTitle,
                    IsCheckingOutOnArrival = x.RoomBookings.Any(b =>
                                            b.Status == BookingStatus.Booked &&
                                            b.NightStay == true &&
                                            b.Date.HasValue &&
                                            b.Date.Value.Date == yesterday)
                }).ToList() // Bring to memory to build the DisplayName string
                .Select(x => new ListboxItemAvailableRooms
                {
                    ID = x.ID,
                    RoomNumber = x.RoomNumber!,
                    IsCheckoutToday = x.IsCheckingOutOnArrival,
                    // If checking out today, add a clear visual indicator like (CO) or ⟳
                    DisplayName = x.IsCheckingOutOnArrival
                        ? $"{x.RoomNumber} - {x.RoomTitle} [✔]"
                        : $"{x.RoomNumber} - {x.RoomTitle}"
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
            DateTime fromDate = dtpFromDateTime.Value;
            DateTime toDate = dtpToDateTime.Value;
            var selectedGuest = cmbGuests.SelectedItem as GuestComboBoxItem;
            var guestId = selectedGuest != null ? selectedGuest.ID : 0; // Get selected guest ID

            foreach (var selectedRoom in listBox1.SelectedItems.Cast<ListboxItemAvailableRooms>())
            {
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
                        Amount = Convert.ToDecimal(txtPricePerNight.Text),
                        TaxPercentage = chkIsGSTApplicable.Checked ? 5 : 0,
                        // Assuming price per night is a property of TblRoom
                    });
                }

                //Removed Last Day Entry
                //bookingGridSource.Add(new TblRoomBooking
                //{
                //    ID = 0,
                //    HotelID = HotelID,
                //    BookingMasterID = 0,
                //    GuestID = guestId,
                //    RoomID = selectedRoom.ID,
                //    Status = BookingStatus.Booked,
                //    Date = toDate,
                //    NightStay = false, //Last entry for checkout day
                //    AdultCount = Convert.ToInt32(txtAdult.Text),
                //    ChildCount = Convert.ToInt32(txtChild.Text),
                //    Amount = 0
                //});

            }

            CalculateTotals();
            grpBox.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void CalculateTotals()
        {
            var selectedGuest = cmbGuests.SelectedItem as GuestComboBoxItem;
            var guestId = selectedGuest != null ? selectedGuest.ID : 0; // Get selected guest ID

            var guestStateCodeAll = paymentService.AllGuestStateCodes();
            var guestStateCode = guestStateCodeAll.FirstOrDefault(x => x.GuestID == guestId)!.StateCode;
            bool isGstApplicable = chkIsGSTApplicable.Checked;
            bool isInterState = "GJ" != guestStateCode;
            bool isTaxInclusive = chkISTaxInclusive.Checked;
            decimal gstAmount = 0;
            decimal sGST = 0;
            decimal cGST = 0;
            decimal iGST = 0;
            decimal totalGST = sGST + cGST + iGST;
            var grossAmount = bookingGridSource.Sum(x => x.Amount);
            decimal discount = txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0;
            decimal amountAfterDiscount = grossAmount - discount;

            // Get GST Percentage....
            decimal perNightAverage = bookingGridSource.Any() ? bookingGridSource.Where(b => b.NightStay == true).Average(rb => rb.Amount) : 0;
            decimal gstPercentage = 0;

            //if (!isGstApplicable || perNightAverage < 1000)
            //    gstPercentage = 0;
            //else if (perNightAverage < 7500)
            //    gstPercentage = 12;
            //else
            //    gstPercentage = 18;

            if (isGstApplicable)  //FIX GST As per client demand.
                gstPercentage = 5;

            // Get GST Amount
            if (!isGstApplicable || gstPercentage == 0)
                gstAmount = 0;
            else
                gstAmount = isTaxInclusive
                    ? amountAfterDiscount - (amountAfterDiscount * 100 / (100 + gstPercentage))
                    : amountAfterDiscount * gstPercentage / 100;

            lblIGST.Text = isInterState ? gstAmount.ToString("C0") : "0";
            lblCGST.Text = !isInterState ? (gstAmount / 2).ToString("C0") : "0";
            lblSGST.Text = !isInterState ? (gstAmount / 2).ToString("C0") : "0";
            lblTotalAmount.Text = grossAmount.ToString("C0");
            lblTotal.Text = !isTaxInclusive ? (grossAmount - discount).ToString("C0") : (grossAmount - discount - gstAmount).ToString("C0");
            lblGSTPercentage.Text = gstPercentage.ToString("N2");
            decimal finalAmount = isTaxInclusive ? amountAfterDiscount : amountAfterDiscount + gstAmount;
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
            int guestID = (int)cmbGuests.SelectedValue!;
            var currentDate = DateTime.UtcNow.GetIndianTime();
            roomService.GenerateInvoiceNumber(HotelID, out currentNumber, out transactionSequence, out invoiceNumber);

            var guestStateCodes = paymentService.AllGuestStateCodes();
            string stateCode = guestStateCodes.FirstOrDefault(x => x.GuestID == guestID)!.StateCode!;

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
                    CheckOutDate = bookingGridSource.LastOrDefault()!.Date!.Value.Date.AddDays(1).AddHours(8).AddMinutes(30),
                    Discount = txtDiscount.Text != "" ? Convert.ToDecimal(txtDiscount.Text) : 0,
                    InputTaxCredit = chkInputCreditTax.Checked,
                    HotelStateCode = HotelStateCode,
                    GuestStateCode = stateCode,
                    IsGSTApplicable = chkIsGSTApplicable.Checked,
                    IsTaxInclusive = chkISTaxInclusive.Checked,
                    CreatedOn = currentDate,
                    IsActive = true,
                    IsDeleted = false
                },
                RoomBookings = bookingGridSource.ToList()
            });

            grpBox.Enabled = true;

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
            grpBox.Enabled = true;
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
