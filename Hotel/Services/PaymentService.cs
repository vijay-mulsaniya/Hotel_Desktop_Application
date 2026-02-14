using Hotel.Data;
using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Forms;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Hotel.Services
{
    public interface IPaymentService
    {
        Task<List<GuestComboBoxItem>> Guests();
        Task<List<BillingDto>> BillingGrid();
        Task<List<RoomBookingDto>> RoomBookings(int bookingMasterID);
        Task<List<PaymentDetailsDto>> GetPaymentDetails(int bookingMasterID);
        Task<PaymentDetailsDto> AddPayment(PaymentDetailsDto form);
    }
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext context;
        private static int HotelID = 1;

        public PaymentService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<GuestComboBoxItem>> Guests()
        {
            return await context.Guests.Where(g => g.HotelID == HotelID)
                                 .OrderBy(x => x.FirstName)
                                 .Select(x => new GuestComboBoxItem
                                 {
                                     ID = x.ID,
                                     DisplayName = $"{x.FirstName} - Mo: {x.PhoneNumber}"
                                 }).ToListAsync();

        }
        public async Task<List<BillingDto>> BillingGrid()
        {
            var data = await context.BookingMasters
                .AsNoTracking()
                .Where(b => b.HotelID == HotelID)
                .Select(b => new BillingDto
                {
                    ID = b.ID,
                    BookingMasterID = b.ID,
                    InvoiceNumber = b.InvoiceNumber,
                    BillDate = b.CreatedOn ?? DateTime.Now,
                    Discount = b.Discount,

                    GuestName = b.Guest != null
                        ? b.Guest.FirstName + " - Mo: " + b.Guest.PhoneNumber
                        : "Unknown",

                    // Let's change how we sum to be more robust
                    Total = b.RoomBookings
                        .Where(r => r.BookingMasterID == b.ID) // Explicitly link the ID
                        .Where(r => r.NightStay == true)       // Only count the stays
                        .Sum(r => (decimal?)r.Amount) ?? 0,    // Should result in 7500

                    Paid = b.Payments
                        .Where(p => p.BookingMasterID == b.ID)
                        .Sum(p => (decimal?)p.AmountPaid) ?? 0
                })
                .ToListAsync();

            // After fetching, calculate the final balance in memory to ensure accuracy
            foreach (var item in data)
            {
                item.PayableAmount = item.Total - item.Discount;
                item.Pending = item.PayableAmount - item.Paid;
            }

            return data.OrderByDescending(x => x.BillDate).ToList();
        }
        public async Task<List<RoomBookingDto>> RoomBookings(int bookingMasterID)
        {
            var roomBookings = await context.RoomBookings
                .AsNoTracking()
                .Where(rb => rb.BookingMasterID == bookingMasterID)
                .Select(rb => new RoomBookingDto
                {
                    ID = rb.ID,
                    HotelID = rb.HotelID,
                    BookingMasterID = rb.BookingMasterID,
                    RoomID = rb.RoomID,
                    GuestID = rb.GuestID,
                    Status = rb.Status,
                    Date = rb.Date,
                    NightStay = rb.NightStay,
                    NightStaySymbol = rb.NightStay == true ? "✔" : "✘",
                    AdultCount = rb.AdultCount,
                    ChildCount = rb.ChildCount,
                    Amount = rb.Amount,
                    GuestName = rb.Guest != null ? rb.Guest.FirstName! : "Unknown",
                    RoomNumber = rb.Room != null ? rb.Room.RoomNumber! : "Unknown",
                    RoomTitle = rb.Room != null ? rb.Room.RoomTitle! : "Unknown"
                    //Room = rb.Room,
                    //Guest = rb.Guest
                }).ToListAsync();
            return roomBookings;
        }
        public async Task<List<PaymentDetailsDto>> GetPaymentDetails(int bookingMasterID)
        {
            var payment = await context.Payments
                .Where(p => p.BookingMasterID == bookingMasterID)
                .OrderByDescending(p => p.PaymentDate)
                .Select(p => new PaymentDetailsDto
                {
                    ID = p.ID,
                    BookingMasterID = p.BookingMasterID,
                    PaymentDate = p.PaymentDate,
                    Amount = p.AmountPaid,
                    PaymentMethod = (PaymentMethod)p.Method!,
                    OnlineTransactionRefNumber = p.OnlineTransacionRefNumber,
                    RoomNumber = p.Room!.RoomNumber,
                    InvoiceNumber = p.BookingMaster!.InvoiceNumber
                }).ToListAsync();

            return payment;
        }
        public async Task<PaymentDetailsDto> AddPayment(PaymentDetailsDto form)
        {
            if (form.Amount <= 0)
                throw new InvalidOperationException("Invalid payment amount");

            var payment = new TblPayment
            {
                HotelID = form.HotelID,
                BookingMasterID = form.BookingMasterID,
                RoomID = form.RoomID,
                PaymentDate = form.PaymentDate,
                AmountPaid = form.Amount,
                Method = form.PaymentMethod,
                OnlineTransacionRefNumber = form.OnlineTransactionRefNumber
            };
            context.Payments.Add(payment);
            await context.SaveChangesAsync();
            return new PaymentDetailsDto
            {
                ID = payment.ID,
                HotelID = payment.HotelID,
                BookingMasterID = payment.BookingMasterID,
                RoomID = payment.RoomID ?? 0,
                PaymentDate = payment.PaymentDate,
                Amount = payment.AmountPaid,
                PaymentMethod = (PaymentMethod)payment.Method!,
                OnlineTransactionRefNumber = payment.OnlineTransacionRefNumber
            };
        }
    }
}
