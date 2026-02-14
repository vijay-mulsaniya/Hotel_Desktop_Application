using Hotel.Common;
using Hotel.Data;
using Hotel.Dtos;
using Hotel.Models;
using Hotel.UserControls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel.Forms
{
    public partial class frmBooking : Form
    {
        private readonly IRepository<TblRoom> repository;
        private readonly AppDbContext context;
        private readonly IServiceProvider serviceProvider;
        private readonly MainForm mainForm;
        private static int HotelID = 1;
        public frmBooking(IRepository<TblRoom> repository, AppDbContext context, IServiceProvider serviceProvider, MainForm mainForm)
        {
            InitializeComponent();
            this.repository = repository;
            this.context = context;
            this.serviceProvider = serviceProvider;
            this.mainForm = mainForm;
            dtpDate.Value = DateTime.Now.Date;
        }

        private void frmBooking_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }

        private void LoadRooms()
        {
            flowLayoutPanel1.Controls.Clear();

            var roomData = GetRooms(dtpDate);
            var allRooms = roomData.RoomList;
            lblAvailableTotal.Text = roomData.AvailableRooms.ToString();
            lblBookedTotal.Text = roomData.BookedRooms.ToString();
            lblTotalRooms.Text = roomData.TotalRooms.ToString();
            lblAsOn.Text = roomData.Daytype;

            foreach (var titleCount in roomData.RoomStatusByTitle)
            {
                string count = $"Booked {titleCount.BookedCount} of {titleCount.TotalCount}";

                if (titleCount.Title == "Deluxe Room")
                    lblDeluxeTotal.Text = count;
                else if (titleCount.Title == "Standard Room")
                    lblStandardRoomCount.Text = count;
                else if (titleCount.Title == "Dormitory")
                    lblDormatryCount.Text = count;
            }


            foreach (var room in allRooms)
            {
                RoomCard card = new RoomCard();
                card.RoomId = room.ID;
                card.RoomNumber = room.RoomNumber!;
                card.RoomTitle = room.RoomTitle ?? "";
                card.PricePerNight = room.Charges;
                card.Capacity = room.Capacity;
                card.IsAvailable = room.IsAvailable;
                card.CheckInDate = dtpDate.Value.Date.AddHours(8);

                if (!room.IsAvailable)
                {
                    card.GuestName = room.GuestName!;
                    card.CheckInDate = room.CheckInDate!.Value;
                    card.CheckOutDate = room.CheckOutDate!.Value;
                    card.PersonCount = room.PersonCount;
                    card.NightCount = room.Nights;
                    card.TotalAmount = room.TotalCharges;
                    card.PaidAmount = room.PaidAmount;
                    card.PendingAmount = room.DueAmount;
                    card.BookingMasterId = room.BookingMasterId;    
                }
                AddRoom(card);
            }
        }

        private RoomStatusAllDto GetRooms(DateTimePicker dtp)
        {

            var bookedRoom = context.RoomBookings
                .Include(rb => rb.Guest)
                .Include(rb => rb.BookingMaster).ThenInclude(bm => bm!.Payments)
                .Where(rb => rb.HotelID == HotelID &&
                    rb.Status == BookingStatus.Booked &&
                    rb.NightStay == true &&
                    rb.Date!.Value.Date == dtp.Value.Date)
                .Select(x => new HotelRoom
                {
                    RoomId = x.RoomID,
                    RoomNumber = x.Room!.RoomNumber ?? "",
                    BookingMasterId = x.BookingMaster!.ID,
                    RoomTitle = x.Room.RoomTitle ?? "",
                    GuestName = x.Guest!.FirstName ?? "",
                    CheckinDate = x.BookingMaster!.CheckInDate,
                    CheckoutDate = x.BookingMaster.CheckOutDate,
                    PersonCount = $"A: {x.AdultCount}, C: {x.ChildCount}",
                    NightCount = context.RoomBookings.Where(b => b.BookingMasterID == x.BookingMasterID && b.NightStay == true && x.RoomID == b.RoomID).Count(),
                    TotalAmount = context.RoomBookings.Where(b => b.BookingMasterID == x.BookingMasterID && b.NightStay == true && x.RoomID == b.RoomID).Sum(a => a.Amount),
                    PaidAmount = x.BookingMaster.Payments.Where(r => r.RoomID == x.RoomID).Sum(p => p.AmountPaid),
                    PendingAmount = x.Amount - x.BookingMaster.Payments.Where(r => r.RoomID == x.RoomID).Sum(p => p.AmountPaid)
                }).ToList();

            var result = context.Rooms
                        .Where(r => r.HotelID == HotelID)
                        .AsEnumerable()
                        .Select(x =>
                        {
                            var booking = bookedRoom.FirstOrDefault(b => b.RoomId == x.ID);
                            string roomType = x.RoomType switch
                            {
                                RoomType.Dormitory => "Dormitory",
                                RoomType.Standard => "Double",
                                RoomType.Deluxe => "Deluxe",
                                RoomType.SuperDeluxe => "Super Deluxe",
                                RoomType.Luxery => "Luxery",
                                _ => "Unknown"
                            };

                            return new BookedRoomDto
                            {
                                // -------- ROOM --------
                                ID = x.ID,
                                HotelID = x.HotelID,
                                RoomNumber = x.RoomNumber,
                                RoomTitle = x.RoomTitle,
                                RoomType = roomType,
                                Description = x.Description,
                                Capacity = x.Capacity,
                                Charges = x.Charges,
                                IsClean = x.IsClean,
                                IsAvailable = booking == null,

                                // -------- BOOKING (if any) --------
                                GuestName = booking?.GuestName,
                                CheckInDate = booking?.CheckinDate,
                                CheckOutDate = booking?.CheckoutDate,
                                PersonCount = booking?.PersonCount ?? "",
                                Nights = booking?.NightCount ?? 0,
                                BookingMasterId = booking?.BookingMasterId ?? 0,
                                TotalCharges = booking?.TotalAmount ?? 0,
                                PaidAmount = booking?.PaidAmount ?? 0,
                                FoodCharges = 0,
                            };
                        }).ToList();

            var groupbyTitle = result.GroupBy(x => x.RoomTitle);

            var roomStatusAllDto = new RoomStatusAllDto
            {
                SelectedDate = dtp.Value,
                BookedRooms = result.Count(r => !r.IsAvailable),
                AvailableRooms = result.Count(r => r.IsAvailable),
                RoomStatusByTitle = groupbyTitle.Select(g => new TitleCountDto
                {
                    Title = g.Key ?? "Unknown",
                    AvailableCount = g.Count(r => r.IsAvailable),
                    BookedCount = g.Count(r => !r.IsAvailable)
                }).ToList(),

                RoomList = result
            };

            return roomStatusAllDto;
        }

        void AddRoom(RoomCard card)
        {
            if (!card.IsAvailable)
            {
                HotelRoom room = new HotelRoom();
                room.RoomId = card.RoomId;
                room.RoomNumber = card.RoomNumber;
                room.RoomTitle = card.RoomTitle;
                room.GuestName = card.GuestName;
                room.TotalAmount = card.TotalAmount;
                room.PaidAmount = card.PaidAmount;
                room.PendingAmount = card.PendingAmount;
                room.NightCount = card.NightCount;
                room.TotalAmount = card.TotalAmount;
                room.CheckinDate = card.CheckInDate;
                room.CheckoutDate = card.CheckOutDate;
                room.PersonCount = card.PersonCount;
                room.BookingMasterId = card.BookingMasterId;
                flowLayoutPanel1.Controls.Add(room);
            }
            else
            {
                HotelRoomAvailable room = new HotelRoomAvailable(serviceProvider, mainForm);
                room.RoomId = card.RoomId;
                room.SelectedCheckInDate = lblAsOn.Text == "Today" ? DateTime.UtcNow.GetIndianTime() : dtpDate.Value.Date.AddHours(9);
                room.RoomNumber = card.RoomNumber;
                room.RoomTitle = card.RoomTitle;
                room.Capacity = card.Capacity;
                room.ChargesPerNight = card.PricePerNight;
                room.BackColor = setBackground(card.RoomTitle);
                flowLayoutPanel1.Controls.Add(room);
            }
        }

        private Color setBackground(string title)
        {
            return title switch
            {
                "Deluxe Room" => Color.Aqua,
                "Standard Room" => Color.Beige,
                "Dormitory" => Color.LightPink,
                _ => Color.White
            };
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRooms();
        }
    }

    public class RoomCard
    {
        public int RoomId { get; set; }
        public int BookingMasterId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public RoomType RoomType { get; set; }
        public string RoomTitle { get; set; } = string.Empty;
        public string GuestName { get; set; } = string.Empty;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string PersonCount { get; set; } = string.Empty;
        public int NightCount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public bool IsAvailable { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }

}
