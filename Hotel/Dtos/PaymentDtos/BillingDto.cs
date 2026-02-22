using Hotel.Models;

namespace Hotel.Dtos.PaymentDtos
{
    public class BillingDto
    {
        public int ID { get; set; }
        public int BookingMasterID { get; set; }
        public string? InvoiceNumber { get; set; }
        public string GuestName { get; set; } = null!;
        public int GuestID { get; set; }
        public string GuestStateCode { get; set; } = null!;
        public DateTime BillDate { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal PayableAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal Pending { get; set; }

        public bool InputTaxCredit { get; set; }
        public string HotelStateCode { get; set; } = null!;
        public bool IsGSTApplicable { get; set; } = false;
        public bool IsTaxInclusive { get; set; } = false;

        //public List<RoomBookingDto> RoomDetails { get; set; } = new List<RoomBookingDto>();
    }

    public class PaymentDetailsDto
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public int BookingMasterID { get; set; }
        public int? RoomID { get; set; }
        public string? RoomNumber { get; set; }
        public string? InvoiceNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public string? OnlineTransactionRefNumber { get; set; }
    }
}
