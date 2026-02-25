using Hotel.Common;
using Hotel.Data;
using Hotel.Dtos;
using Hotel.Models;
using Hotel.UserControls;
using System.Data;

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
            flowLayoutPanel1.SuspendLayout(); // Stop layout logic to increase speed
            flowLayoutPanel1.Controls.Clear();

            var roomData = GetRooms(dtpDate.Value);

            // Update Header Stats
            lblAvailableTotal.Text = roomData.AvailableRooms.ToString();
            lblBookedTotal.Text = roomData.BookedRooms.ToString();
            lblTotalRooms.Text = roomData.TotalRooms.ToString();
            lblAsOn.Text = roomData.Daytype;

            // Loop through all rooms
            foreach (var room in roomData.RoomList)
            {
                // The IsCheckOutCard logic is now driven by the DTO we optimized earlier
                bool isCheckingOutToday = room.CheckOutDate?.Date == dtpDate.Value.Date;

                if (!room.IsAvailable)
                {
                    var bookedCard = new HotelRoom
                    {
                        RoomId = room.ID,
                        RoomNumber = room.RoomNumber!,
                        RoomTitle = room.RoomTitle!,
                        GuestName = room.GuestName!,
                        CheckinDate = room.CheckInDate,
                        CheckoutDate = room.CheckOutDate,
                        TotalAmount = room.TotalCharges,
                        PaidAmount = room.PaidAmount,
                        PendingAmount = room.PaidAmount - room.TotalCharges, // Calculate or use DTO
                        NightCount = room.Nights,
                        BookingMasterId = room.BookingMasterId,
                        PersonCount = room.PersonCount,
                        IsCheckOutCard = isCheckingOutToday // This triggers UpdateStatusUI()
                    };
                    flowLayoutPanel1.Controls.Add(bookedCard);
                }
                else
                {
                    var availCard = new HotelRoomAvailable(serviceProvider, mainForm)
                    {
                        RoomId = room.ID,
                        RoomNumber = room.RoomNumber!,
                        RoomTitle = room.RoomTitle!,
                        Capacity = room.Capacity,
                        ChargesPerNight = room.Charges,
                        IsCheckOutCard = isCheckingOutToday,
                        SelectedCheckInDate = lblAsOn.Text == "Today"
                            ? DateTime.Now
                            : dtpDate.Value.Date.AddHours(9)
                    };
                    // Set the category color
                    availCard.BackColor = setBackground(room.RoomTitle!);
                    flowLayoutPanel1.Controls.Add(availCard);
                }
            }

            flowLayoutPanel1.ResumeLayout(); // Refresh layout all at once
        }
        //private void LoadRooms()
        //{
        //    flowLayoutPanel1.SuspendLayout(); // Stop layout logic to increase speed
        //    flowLayoutPanel1.Controls.Clear();

        //    var roomData = GetRooms(dtpDate.Value);
        //    var allRooms = roomData.RoomList;
        //    lblAvailableTotal.Text = roomData.AvailableRooms.ToString();
        //    lblBookedTotal.Text = roomData.BookedRooms.ToString();
        //    lblTotalRooms.Text = roomData.TotalRooms.ToString();
        //    lblAsOn.Text = roomData.Daytype;

        //    foreach (var titleCount in roomData.RoomStatusByTitle)
        //    {
        //        string count = $"Booked {titleCount.BookedCount} of {titleCount.TotalCount}";

        //        if (titleCount.Title == "Deluxe Room")
        //            lblDeluxeTotal.Text = count;
        //        else if (titleCount.Title == "Standard Room")
        //            lblStandardRoomCount.Text = count;
        //        else if (titleCount.Title == "Dormitory")
        //            lblDormatryCount.Text = count;
        //    }

        //    foreach (var room in allRooms)
        //    {
        //        RoomCard card = new RoomCard();
        //        card.RoomId = room.ID;
        //        card.RoomNumber = room.RoomNumber!;
        //        card.RoomTitle = room.RoomTitle ?? "";
        //        card.PricePerNight = room.Charges;
        //        card.Capacity = room.Capacity;
        //        card.IsAvailable = room.IsAvailable;
        //        card.CheckInDate = dtpDate.Value.Date.AddHours(8);
        //        card.IsCheckOutCard = room.CheckOutDate?.Date == dtpDate.Value.Date;

        //        if (!room.IsAvailable)
        //        {
        //            card.GuestName = room.GuestName!;
        //            card.CheckInDate = room.CheckInDate!.Value;
        //            card.CheckOutDate = room.CheckOutDate!.Value;
        //            card.PersonCount = room.PersonCount;
        //            card.NightCount = room.Nights;
        //            card.TotalAmount = room.TotalCharges;
        //            card.PaidAmount = room.PaidAmount;
        //            card.PendingAmount = room.DueAmount;
        //            card.BookingMasterId = room.BookingMasterId;
        //        }
        //        Debug.WriteLine($"Room {room.RoomNumber} CheckoutFlag: {room.IsCheckOutCard}");
        //        AddRoom(card);
        //    }

        //    flowLayoutPanel1.ResumeLayout(); // Refresh layout all at once
        //}

        private RoomStatusAllDto GetRooms(DateTime selectedDate)
        {
            var dateOnly = selectedDate.Date;
            var yesterday = dateOnly.AddDays(-1);

            var relevantBookings = context.RoomBookings
            .Where(rb => rb.HotelID == HotelID &&
                     rb.Status == BookingStatus.Booked &&
                     rb.NightStay == true &&
                     (rb.Date!.Value.Date == dateOnly || rb.Date.Value.Date == yesterday))
                    .Select(rb => new
                    {
                        rb.RoomID,
                        rb.Date, // To distinguish between today's guest and yesterday's guest
                        rb.Amount,
                        rb.AdultCount,
                        rb.ChildCount,
                        GuestName = rb.Guest != null ? rb.Guest.FirstName : "",
                        Master = rb.BookingMaster,
                        LastNightDate = rb.BookingMaster!.RoomBookings
                            .Where(x => x.RoomID == rb.RoomID && x.NightStay == true)
                            .Max(x => x.Date),
                        TotalBookingAmount = rb.BookingMaster.RoomBookings
                            .Where(x => x.RoomID == rb.RoomID && x.NightStay == true).Sum(x => x.Amount),
                        NightCount = rb.BookingMaster.RoomBookings
                            .Count(x => x.RoomID == rb.RoomID && x.NightStay == true),
                        PaidAmount = rb.BookingMaster.Payments
                            .Where(p => p.RoomID == rb.RoomID).Sum(p => p.AmountPaid)
                    }).ToList();

            var allRooms = context.Rooms.Where(r => r.HotelID == HotelID).ToList();

            var roomList = allRooms.Select(x =>
            {
                var stayedLastNight = relevantBookings.FirstOrDefault(b => b.RoomID == x.ID && b.Date!.Value.Date == yesterday);
                var stayingTonight = relevantBookings.FirstOrDefault(b => b.RoomID == x.ID && b.Date!.Value.Date == dateOnly);

                bool isCheckingOutToday = false;
                if (stayedLastNight != null)
                {
                    // If they stayed last night (25th) but are NOT staying tonight (26th), 
                    // they are definitely checking out today.
                    if (stayingTonight == null)
                    {
                        isCheckingOutToday = true;
                    }
                    // OR: If your 'LastNightDate' logic confirms their stay ends this morning
                    else if (stayedLastNight.LastNightDate!.Value.Date == yesterday)
                    {
                        isCheckingOutToday = true;
                    }
                }
                var displayBooking = stayingTonight ?? stayedLastNight;

                if (displayBooking != null)
                {
                    var checkoutDate = displayBooking.LastNightDate!.Value.Date.AddDays(1);
                    isCheckingOutToday = checkoutDate == dateOnly;
                }

                //bookingsAtDate.TryGetValue(x.ID, out var booking);

                //// 2. Calculate Dynamic Checkout: MaxDate + 1 Day + 08:30 AM
                //DateTime? dynamicCheckout = null;
                //if (booking?.LastNightDate != null)
                //{
                //    dynamicCheckout = booking.LastNightDate.Value.Date
                //                        .AddDays(1)
                //                        .AddHours(8)
                //                        .AddMinutes(30);
                //}

                return new BookedRoomDto
                {
                    ID = x.ID,
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    RoomTitle = x.RoomTitle,
                    RoomType = GetRoomTypeString(x.RoomType),
                    IsAvailable = stayingTonight == null,

                    // Booking Details
                    GuestName = displayBooking?.GuestName,
                    CheckInDate = displayBooking?.Master?.CheckInDate,

                    // Apply the dynamic checkout here
                    CheckOutDate = displayBooking?.LastNightDate!.Value.Date.AddDays(1).AddHours(8).AddMinutes(30),

                    PersonCount = displayBooking != null ? $"A: {displayBooking.AdultCount}, C: {displayBooking.ChildCount}" : "",
                    Nights = displayBooking?.NightCount ?? 0,
                    BookingMasterId = displayBooking?.Master?.ID ?? 0,
                    TotalCharges = displayBooking?.TotalBookingAmount ?? 0,
                    PaidAmount = displayBooking?.PaidAmount ?? 0,
                    FoodCharges = 0
                };
            }).ToList();

            return new RoomStatusAllDto
            {
                SelectedDate = selectedDate,
                BookedRooms = roomList.Count(r => !r.IsAvailable),
                AvailableRooms = roomList.Count(r => r.IsAvailable),
                RoomList = roomList,
                RoomStatusByTitle = roomList
                    .GroupBy(x => x.RoomTitle)
                    .Select(g => new TitleCountDto
                    {
                        Title = g.Key ?? "Unknown",
                        AvailableCount = g.Count(r => r.IsAvailable),
                        BookedCount = g.Count(r => !r.IsAvailable)
                    }).ToList()
            };
        }

        private string GetRoomTypeString(RoomType? type) => type switch
        {
            RoomType.Dormitory => "Dormitory",
            RoomType.Standard => "Double",
            RoomType.Deluxe => "Deluxe",
            RoomType.SuperDeluxe => "Super Deluxe",
            RoomType.Luxery => "Luxery",
            _ => "Unknown"
        };

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
                room.IsCheckOutCard = card.IsCheckOutCard;
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
                room.IsCheckOutCard = card.IsCheckOutCard;
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
        public bool IsCheckOutCard { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }

}
