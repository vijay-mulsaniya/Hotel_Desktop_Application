using Hotel.Common;
using Hotel.Data;
using Hotel.Forms;
using Hotel.Models;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.UserControls
{
    public partial class HotelRoomAvailable : UserControl
    {
        private readonly IServiceProvider serviceProvider;
        private readonly MainForm mainForm;
        private DateTime _selectedCheckInDate;
        private bool _isCheckOutCard;
        private bool _isDirty;
        private bool _isLateCheckout;
        private int _bookingMasterId;
        public event EventHandler? OnStatusChanged;

        public HotelRoomAvailable(IServiceProvider serviceProvider, MainForm mainForm)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.mainForm = mainForm;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string GuestName
        {
            get => lblGuestName.Text;
            set
            {
                lblGuestName.Text = value;
                lblGuestName.Visible = !string.IsNullOrEmpty(value); // Only show if there's a name
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedCheckInDate
        {
            get => _selectedCheckInDate;
            set => _selectedCheckInDate = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomNumber
        {
            get => lblRoomNumber.Text;
            set => lblRoomNumber.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string RoomTitle
        {
            get => lblRoomTitle.Text;
            set => lblRoomTitle.Text = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Capacity
        {
            get => Convert.ToInt32(lblCapacity);
            set => lblCapacity.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RoomId
        {
            get => Convert.ToInt32(lblRoomId.Text);
            set => lblRoomId.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BookingMasterID
        {
            get => _bookingMasterId;
            set => _bookingMasterId = value;
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal ChargesPerNight
        {
            get => Convert.ToDecimal(lblCharges);
            set => lblCharges.Text = value.ToString();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsCheckOutCard
        {
            get => _isCheckOutCard;
            set
            {
                _isCheckOutCard = value;
                UpdateStatusUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsLateCheckout
        {
            get => _isLateCheckout;
            set
            {
                _isLateCheckout = value;
                UpdateStatusUI();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                UpdateStatusUI();
            }
        }

        private void UpdateStatusUI()
        {
            lblCheckOutToday.Visible = false;
            lblGuestName.Visible = !string.IsNullOrEmpty(GuestName);

            if (IsCheckOutCard)
            {
                lblCheckOutToday.Visible = true;

                if (IsLateCheckout)
                {
                    // ALARM STATE: Bright Red
                    this.BackColor = Color.MistyRose;
                    lblRoomNumber.BackColor = Color.Red;
                    lblCheckOutToday.Text = "LATE CHECKOUT!";
                    lblCheckOutToday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    lblCheckOutToday.ForeColor = Color.Red;
                }
                else
                {
                    this.BackColor = Color.LavenderBlush;
                    lblRoomNumber.BackColor = Color.Maroon;
                    lblCheckOutToday.Visible = true;
                    lblCheckOutToday.Text = "DEPARTING";
                    btnBookNow.Text = "Check Out";
                    btnBookNow.BackColor = Color.Maroon;
                    btnBookNow.ForeColor = Color.White;
                }

                btnBookNow.Text = "Check Out";
                btnBookNow.BackColor = Color.Maroon;
                btnBookNow.ForeColor = Color.White;
            }
            else if (IsDirty) // Guest left, but housekeeping hasn't finished
            {
                this.BackColor = Color.LightGoldenrodYellow;
                lblRoomNumber.BackColor = Color.Orange;
                lblCheckOutToday.Visible = true;
                lblCheckOutToday.Text = "DIRTY";
                btnBookNow.Text = "Mark Clean";
                btnBookNow.BackColor = Color.Orange;
                btnBookNow.ForeColor = Color.Black;

                //this.BackColor = Color.LightGoldenrodYellow;
                //lblRoomNumber.BackColor = Color.Orange;
                //btnBookNow.Text = "Mark Clean";
            }
            else
            {
                //lblGuestName.Text = "";
                //btnBookNow.Text = "Book Now";
                //btnBookNow.BackColor = Color.Gainsboro; // Or your default
                //btnBookNow.ForeColor = Color.Black;

                lblGuestName.Text = "";
                btnBookNow.Text = "Book Now";
                btnBookNow.BackColor = Color.Gainsboro;
                btnBookNow.ForeColor = Color.Black;
                lblRoomNumber.BackColor = Color.FromArgb(0, 0, 0, 0);
            }
        }
        private void btnBookNow_Click(object sender, EventArgs e)
        {
            if (IsCheckOutCard)
            {
                HandleCheckout();
            }
            else if (IsDirty) // New State
            {
                HandleMarkClean();
            }
            else
            {
                HandleNewBooking();
            }
        }
        private void HandleCheckout()
        {
            var result = MessageBox.Show($"Confirm Checkout for {GuestName} (Room {RoomNumber})?",
                                       "Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ProcessRoomCheckout(BookingMasterID, RoomId);

                this.IsCheckOutCard = false;
                this.GuestName = "";
                UpdateStatusUI(); // Resets colors and button text

                // 3. Optional: Refresh the parent flow layout to update stats
                // this.ParentForm.LoadRooms(); 
            }
        }
        public void ProcessRoomCheckout(int bookingMasterId, int roomId)
        {
            using (var db = new AppDbContext())
            {
                // 1. Find the last night entry for this specific room in this booking
                var lastNightEntry = db.RoomBookings
                    .Where(rb => rb.BookingMasterID == bookingMasterId && rb.RoomID == roomId)
                    .OrderByDescending(rb => rb.Date)
                    .FirstOrDefault();

                if (lastNightEntry != null)
                {
                    // 2. Mark as Checked Out
                    lastNightEntry.IsCheckedOut = true;
                    lastNightEntry.ActualCheckOutTime = DateTime.UtcNow.GetIndianTime(); // Records the exact moment

                    // 3. Mark as Dirty (Needs cleaning)
                    lastNightEntry.IsCleaned = false;

                    db.SaveChanges();
                }
            }
            OnStatusChanged?.Invoke(this, EventArgs.Empty);
        }
        private void HandleMarkClean()
        {
            if (MessageBox.Show($"Has Room {RoomNumber} been cleaned and inspected?",
                "Housekeeping", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProcessRoomCleaning(this.RoomId);

                // Reset local state so UI updates immediately
                this.IsDirty = false;
                this.GuestName = ""; // Name is definitely removed after cleaning
                UpdateStatusUI();

                // Inform the MainForm to refresh statistics (Total Available/Booked)
                OnStatusChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public void ProcessRoomCleaning(int roomId)
        {
            using (var db = new AppDbContext())
            {
                // Find the most recent record for this room that is checked out but not yet cleaned
                var dirtyRecord = db.RoomBookings
                    .Where(rb => rb.RoomID == roomId && rb.IsCheckedOut && !rb.IsCleaned)
                    .OrderByDescending(rb => rb.Date)
                    .FirstOrDefault();

                if (dirtyRecord != null)
                {
                    dirtyRecord.IsCleaned = true;
                    db.SaveChanges();
                }
            }
        }
        private void HandleNewBooking()
        {
            var bookNow = serviceProvider.GetRequiredService<frmBookNow>();

            if (bookNow != null)
            {

                bookNow.SelectedRoomId = RoomId;
                bookNow.SelectedCheckInDate = SelectedCheckInDate;
                bookNow.MdiParent = this.mainForm;
                bookNow.WindowState = FormWindowState.Maximized;

                foreach (var form in mainForm.MdiChildren)
                {
                    if (form is frmBookNow)
                    {
                        continue;
                    }
                    form.Close();
                }

                bookNow.Show();
            }
        }

        
    }
}
