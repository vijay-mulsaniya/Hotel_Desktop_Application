
using Hotel.Dtos.PaymentDtos;
using Hotel.Models;

namespace Hotel.Dtos
{
    public class BookingInvoiceDto
    {
        // Invoice Info
        public string InvoiceNumber { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }

        // Hotel / Guest
        public string HotelName { get; set; } = null!;
        public string GuestName { get; set; } = null!;
        public string HotelStateCode { get; set; } = null!;
        public string GuestStateCode { get; set; } = null!;

        // GST
        public bool IsGSTApplicable { get; set; } = true;
        public bool IsInterState => HotelStateCode != GuestStateCode;
        public bool IsTaxInclusive { get; set; }

        public string SACCode { get; set; } = "996311";

        // Amounts
       
        public decimal Discount { get; set; }
        public decimal TaxableAmount { get; set; }

        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }

        public decimal TotalGST => CGST + SGST + IGST;
        public decimal GrossAmount => RoomBookings.Sum(rb => rb.Amount);
        public decimal AmountAfterDiscount => GrossAmount - Discount;
        public decimal GSTPercentage
        {
            get
            {
                var perNightAmount = RoomBookings.Any()
                    ? RoomBookings.Average(rb => rb.Amount)
                    : 0;

                if (!IsGSTApplicable) return 0;
                if (perNightAmount < 1000) return 0;
                if (perNightAmount < 7500) return 12;
                return 18;
            }
        }
        public decimal GSTAmount
        {
            get
            {
                if (!IsGSTApplicable || GSTPercentage == 0) return 0;

                return IsTaxInclusive
                    ? AmountAfterDiscount - (AmountAfterDiscount * 100 / (100 + GSTPercentage))
                    : AmountAfterDiscount * GSTPercentage / 100;
            }
        }
        public decimal IGSTAmount => IsInterState ? GSTAmount : 0;
        public decimal CGSTAmount => !IsInterState ? GSTAmount / 2 : 0;
        public decimal SGSTAmount => !IsInterState ? GSTAmount / 2 : 0;
        public decimal NetPayableAmount => IsTaxInclusive ? AmountAfterDiscount : AmountAfterDiscount + GSTAmount;

        public List<RoomBookingDto> RoomBookings { get; set; } = new();
        public List<PaymentDetailsDto> Payments { get; set; } = new();
    }

    public class RoomBookingDto
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int BookingMasterID { get; set; }
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } = null!;
        public string RoomTitle { get; set; } = null!;
        public int GuestID { get; set; }
        public string GuestName { get; set; } = null!;
        public BookingStatus? Status { get; set; } = BookingStatus.Booked;
        public DateTime? Date { get; set; }
        public bool? NightStay { get; set; }
        public string? NightStaySymbol { get; set; }
        public int AdultCount { get; set; } = 1;
        public int ChildCount { get; set; } = 0;
        public int NumberOfGuests { get { return AdultCount + ChildCount; } }
        public decimal Amount { get; set; }
        public TblHotel? Hotel { get; set; }
        public TblRoom? Room { get; set; }
        public TblGuest? Guest { get; set; }
        public TblBookingMaster? TblBookingMaster { get; set; }
    }

    public class AddNewBookingDto
    {
        public TblBookingMaster BookingMaster { get; set; } = null!;
        public List<TblRoomBooking> RoomBookings { get; set; } = new();
    }
    
}
