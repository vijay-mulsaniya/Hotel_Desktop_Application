using Hotel.Common;

namespace Hotel.Models
{
    public class DefaultFields
    {
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow.GetIndianTime();
        public int? CreatedbyId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedbyId { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
        public TblUser? CreatedBy { get; set; }
        public TblUser? UpdatedBy { get; set; }
    }
    public class TblAddress
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int? GuestID { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }
        public string? TableName { get; set; }
        public int? TableID { get; set; }
        public TblHotel? Hotel { get; set; }
        public TblGuest? Guest { get; set; }
    }
    public class TblHotel
    {
        public int ID { get; set; }
        public string? HotelName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public ICollection<TblRoom> Rooms { get; set; } = new HashSet<TblRoom>();
        public ICollection<TblGuest> Guests { get; set; } = new HashSet<TblGuest>();
        public ICollection<TblUser> Users { get; set; } = new HashSet<TblUser>();
    }
    public class TblRoom
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomTitle { get; set; }
        public RoomType? RoomType { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public int Charges { get; set; }
        public bool IsClean { get; set; }
        public bool IsAvailable { get; set; }
        public TblHotel? Hotel { get; set; }
        public ICollection<TblAminities> Aminities { get; set; } = new HashSet<TblAminities>();
        public ICollection<TblRoomBooking> RoomBookings { get; set; } = new HashSet<TblRoomBooking>();
        public ICollection<TblPayment> Payments { get; set; } = new HashSet<TblPayment>();
    }
    public class TblGuest : DefaultFields
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? Email { get; set; }
        public Gender? Gender { get; set; } = null;
        public TblHotel? Hotel { get; set; }

        public ICollection<TblIdentityProof> IdentityProof { get; set; } = new HashSet<TblIdentityProof>();
        public ICollection<TblBookingMaster> BookingMasters { get; set; } = new HashSet<TblBookingMaster>();
    }
    public class TblIdentityProof : DefaultFields
    {
        public int ID { get; set; }
        public int GuestID { get; set; }
        public string? ProofType { get; set; }
        public string? ProofNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? IssuingAuthority { get; set; }
        public string? DocumentUrl { get; set; }
        public bool? IsVerified { get; set; } = false;
        public TblGuest? Guest { get; set; }
    }
    public class TblUser
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public required string UserName { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AvatarUrl { get; set; }
        public string? MobileNumber1 { get; set; }
        public string? MobileNumber2 { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow.GetIndianTime();
        public int? CreatedbyId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedbyId { get; set; }
        public bool? IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;
        public ICollection<TblUserRole> UserRoles { get; set; } = new HashSet<TblUserRole>();
        public TblHotel? Hotel { get; set; }
    }
    public class TblAminities
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int? RoomID { get; set; }
        public string? AmenityName { get; set; }
        public string? Description { get; set; }
        public TblHotel? Hotel { get; set; }
        public TblRoom? Room { get; set; }
    }
    public class TblCleaning : DefaultFields
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int? RoomID { get; set; }
        public bool? IsScheduled { get; set; } = false;
        public DateTime? ScheduledOn { get; set; } // planned schedule date/time
        public DateTime? StartTime { get; set; } //Cleanning Actual time
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration
        {
            get
            {
                if (StartTime.HasValue && EndTime.HasValue)
                    return EndTime - StartTime;
                return null;
            }
        }
        public int? CleanerID { get; set; }             // links to TblUser (staff) who cleaned
        public int? InspectorID { get; set; }           // links to TblUser who inspected
        public bool? IsInspected { get; set; } = false;
        public CleaningType? Type { get; set; } = CleaningType.Standard;
        public CleaningStatus? Status { get; set; } = CleaningStatus.Pending;
        public string? Notes { get; set; }              // general notes about the cleaning
        public string? InspectionNotes { get; set; }    // notes from inspector
        public string? SuppliesUsed { get; set; }       // comma-separated or JSON list of supplies
        public string? PhotoUrls { get; set; } = "[]";  // evidence photos
        public decimal? Cost { get; set; } = 0M;             // optional cost for deep/paid cleanings
        // Navigation properties
        public TblHotel? Hotel { get; set; }
        public TblRoom? Room { get; set; }
        public TblUser? Cleaner { get; set; }
        public TblUser? Inspector { get; set; }
    }
    public class TblBookingMaster : DefaultFields
    {
        public int ID { get; set; }

        public int HotelID { get; set; }
        public int GuestID { get; set; }

        public string? InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public decimal Discount { get; set; } = 0M;

        public bool InputTaxCredit { get; set; }

        public string HotelStateCode { get; set; } = null!;
        public string GuestStateCode { get; set; } = null!;

        public bool IsGSTApplicable { get; set; } = false;
        public bool IsTaxInclusive { get; set; } = false;

        public TblHotel? Hotel { get; set; }
        public TblGuest? Guest { get; set; }

        public ICollection<TblRoomBooking> RoomBookings { get; set; } = new HashSet<TblRoomBooking>();
        public ICollection<TblPayment> Payments { get; set; } = new HashSet<TblPayment>();
    }
    public class TblRoomBooking : DefaultFields
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int BookingMasterID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public BookingStatus? Status { get; set; } = BookingStatus.Booked;
        public DateTime? Date { get; set; }
        public bool? NightStay { get; set; }
        public int AdultCount { get; set; } = 1;
        public int ChildCount { get; set; } = 0;
        public decimal Amount { get; set; } = 0M;
        public decimal TaxPercentage { get; set; } = 0M;

        public TblHotel? Hotel { get; set; }
        public TblRoom? Room { get; set; }
        public TblGuest? Guest { get; set; }
        public TblBookingMaster? BookingMaster { get; set; }
    }
    public class TblPayment : DefaultFields
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int BookingMasterID { get; set; }
        public int? RoomID { get; set; }
        public decimal AmountPaid { get; set; } = 0M;
        public DateTime PaymentDate { get; set; }
        public PaymentMethod? Method { get; set; }
        public string? OnlineTransacionRefNumber { get; set; }  
        public TblHotel? Hotel { get; set; }
        public TblBookingMaster? BookingMaster { get; set; }
        public TblRoom? Room { get; set; }
    }
    public class TblFoodMenu
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string? ItemName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } = 0M;
        public TblHotel? Hotel { get; set; }
    }
    public class TblFoodOrder : DefaultFields
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ItemsJson { get; set; } // JSON representation of ordered items
        public decimal TotalAmount { get; set; } = 0M;
        public string? SpecialInstructions { get; set; }
        public TblHotel? Hotel { get; set; }
        public TblRoom? Room { get; set; }
        public TblGuest? Guest { get; set; }
    }
    public class TblRole
    {
        public int ID { get; set; }
        public required string RoleName { get; set; }
        public string? DisplayNameGujarati { get; set; }
        public ICollection<TblUserRole> UserRoles { get; set; } = new HashSet<TblUserRole>();
    }
    public class TblUserRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public TblUser? User { get; set; }
        public TblRole? Role { get; set; }
    }
    public class TblTransactionSequence
    {
        public int HotelID { get; set; }
        public int TransactionTypeId { get; set; }
        public int LastNumber { get; set; }
    }
    public class TblState
    {
        public int StateID { get; set; }
        public string StateCode { get; set; } = null!;
        public string StateName { get; set; } = null!;

        public ICollection<TblCity> Cities { get; set; } = new HashSet<TblCity>();
    }
    public class TblCity
    {
        public int CityID { get; set; }
        public int StateID { get; set; }
        public string CityName { get; set; } = null!;

        public TblState? State { get; set; }
    }
}