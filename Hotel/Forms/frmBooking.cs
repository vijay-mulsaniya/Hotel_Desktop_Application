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
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            var roomData = GetRooms(dtpDate.Value);

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

            foreach (var room in roomData.RoomList)
            {
                bool isCheckingOutToday = room.IsCheckOutCard;
                bool isDirty = room.IsDirty;
                bool lateCheckout = room.IsLateCheckout;
                bool isAvailableRoomLevel = room.IsAvailableRoomLevel;
                int overStayDays = room.OverStayDays;

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
                        BookingMasterID = room.BookingMasterId,
                        RoomNumber = room.RoomNumber!,
                        RoomTitle = room.RoomTitle!,
                        IsDirty = isDirty,
                        IsLateCheckout = lateCheckout,
                        OverstayNights = overStayDays,
                        IsAvailableRoomLevel = isAvailableRoomLevel,

                        Capacity = room.Capacity,
                        ChargesPerNight = room.Charges,
                        IsCheckOutCard = isCheckingOutToday,
                        GuestName = (isCheckingOutToday || isDirty) ? room.GuestName! : "",
                        SelectedCheckInDate = lblAsOn.Text == "Today"
                            ? DateTime.Now
                            : dtpDate.Value.Date.AddHours(9)
                    };

                    availCard.OnStatusChanged += (s, e) => LoadRooms();
                    availCard.BackColor = setBackground(room.RoomTitle!);

                    flowLayoutPanel1.Controls.Add(availCard);
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }

        private RoomStatusAllDto GetRooms(DateTime selectedDate)
        {
            var dateOnly = selectedDate.Date;
            var yesterday = dateOnly.AddDays(-1);
            TimeSpan checkoutDeadline = new TimeSpan(10, 0, 0);

            var relevantBookings = context.RoomBookings
            .Where(rb => rb.HotelID == HotelID &&
                     rb.Status == BookingStatus.Booked &&
                     rb.NightStay == true &&
                     (rb.Date!.Value.Date == dateOnly || rb.Date.Value.Date == yesterday))
                    .Select(rb => new
                    {
                        rb.RoomID,
                        Date = rb.Date!.Value.Date,
                        rb.Amount,
                        rb.AdultCount,
                        rb.ChildCount,
                        rb.IsCheckedOut,
                        rb.IsCleaned,
                        rb.BookingMasterID,
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
                    }).AsEnumerable() // switch to memory for date calculation
                    .Select(x => new
                    {
                        x.RoomID,
                        x.Date,
                        x.Amount,
                        x.AdultCount,
                        x.ChildCount,
                        x.IsCheckedOut,
                        x.IsCleaned,
                        x.BookingMasterID,
                        x.GuestName,
                        x.LastNightDate,
                        x.Master,
                        x.TotalBookingAmount,
                        x.NightCount,
                        x.PaidAmount,
                        OverStayDays = x.LastNightDate != null &&
                                       x.LastNightDate.Value.Date < dateOnly
                            ? (dateOnly - x.LastNightDate.Value.Date).Days
                            : 0
                    })
                    .ToList();

            var allRooms = context.Rooms.Where(r => r.HotelID == HotelID).ToList(); //***** && r.ID == 15

            var roomList = allRooms.Select(x =>
            {
                var stayedLastNight = relevantBookings.FirstOrDefault(b => b.RoomID == x.ID && b.Date.Date == yesterday);
                var stayingTonight = relevantBookings.FirstOrDefault(b => b.RoomID == x.ID && b.Date.Date == dateOnly);

                var sameInvoiceOtherEntryFound = stayedLastNight != null ? context.RoomBookings.Any(bk => bk.BookingMasterID == stayedLastNight.BookingMasterID
                                                                                && bk.Date!.Value.Date > stayedLastNight.Date.Date) : false;

                bool isCheckingOutToday = (stayedLastNight != null) && (stayingTonight == null) && (!stayedLastNight.IsCheckedOut) && !sameInvoiceOtherEntryFound;
                bool isDirty = stayedLastNight != null && stayedLastNight.IsCheckedOut && !stayedLastNight.IsCleaned;
                var displayBooking = stayingTonight ?? stayedLastNight;
                bool isLate = false;
                if (isCheckingOutToday && dateOnly == DateTime.UtcNow.GetIndianTime().Date)
                {
                    if (DateTime.UtcNow.GetIndianTime().TimeOfDay > checkoutDeadline)
                    {
                        isLate = true;
                    }
                }

                var roomLevelFlag = x.IsAvailable;

                return new BookedRoomDto
                {
                    ID = x.ID,
                    HotelID = x.HotelID,
                    RoomNumber = x.RoomNumber,
                    RoomTitle = x.RoomTitle,
                    RoomType = GetRoomTypeString(x.RoomType),
                    IsAvailable = stayingTonight == null,
                    IsCheckOutCard = isCheckingOutToday,
                    IsDirty = isDirty,
                    IsLateCheckout = isLate,
                    IsAvailableRoomLevel = roomLevelFlag,
                    OverStayDays = displayBooking != null ? displayBooking.OverStayDays : 0,

                    GuestName = displayBooking?.GuestName,
                    CheckInDate = displayBooking?.Master?.CheckInDate,
                    CheckOutDate = displayBooking?.LastNightDate!.Value.Date.AddDays(1).AddHours(8).AddMinutes(30),
                    PersonCount = displayBooking != null ? $"A: {displayBooking.AdultCount}, C: {displayBooking.ChildCount}" : "",
                    Nights = displayBooking?.NightCount ?? 0,
                    BookingMasterId = displayBooking?.Master?.ID ?? 0,
                    TotalCharges = displayBooking?.TotalBookingAmount ?? 0,
                    PaidAmount = displayBooking?.PaidAmount ?? 0,
                    FoodCharges = 0,
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

        private void AddRoom(RoomCard card)
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

        private void timer1_Tick(object sender, EventArgs e)
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
