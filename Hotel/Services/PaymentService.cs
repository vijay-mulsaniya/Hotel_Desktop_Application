using Hotel.Data;
using Hotel.Dtos;
using Hotel.Dtos.PaymentDtos;
using Hotel.Forms;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Documents;

namespace Hotel.Services
{
    public interface IPaymentService
    {
        Task<List<GuestComboBoxItem>> Guests();
        Task<List<BillingDto>> BillingGrid();
        Task<List<RoomBookingDto>> RoomBookings(int bookingMasterID);
        Task<List<PaymentDetailsDto>> GetPaymentDetails(int bookingMasterID);
        Task<PaymentDetailsDto> AddPayment(PaymentDetailsDto form);
        Task<PaymentCollectionReportDto> MonthlyPaymentCollectionReport(int month, int year);
        Task<List<(string stateCode, string stateName)>> GuestStates();
        List<GuestStateCode> AllGuestStateCodes();
        Task<bool> EditInvoiceMaster(BillingDto data);
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
        public async Task<List<(string stateCode, string stateName)>> GuestStates()
        {
            var states = await context.States
                               .OrderBy(x => x.StateName)
                               .Select(x => new { x.StateCode, x.StateName })
                               .ToListAsync();

            return states.Select(x => (x.StateCode, x.StateName)).ToList();
        }
        public async Task<List<BillingDto>> BillingGrid()
        {
            //var guestStateCodes = AllGuestStateCodes();

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

                    GuestID = b.GuestID,
                    GuestName = b.Guest != null
                        ? b.Guest.FirstName + " - Mo: " + b.Guest.PhoneNumber
                        : "Unknown",

                    InputTaxCredit = b.InputTaxCredit,
                    HotelStateCode = b.HotelStateCode,
                    GuestStateCode = b.GuestStateCode,
                    IsGSTApplicable = b.IsGSTApplicable,
                    IsTaxInclusive = b.IsTaxInclusive,
                    

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
                //item.GuestStateCode = guestStateCodes.FirstOrDefault(s => s.GuestID == item.GuestID)!.StateCode!;
            }

            return data.OrderByDescending(x => x.BillDate).ToList();
        }
        public List<GuestStateCode> AllGuestStateCodes()
        {
            return context.Addresses.Select(x => new GuestStateCode
            {
                GuestID = x.GuestID ?? 0,
                State = x.State,
                StateCode = context.States.FirstOrDefault(s => s.StateName == x.State)!.StateCode
            }).ToList();
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
        public async Task<PaymentCollectionReportDto> MonthlyPaymentCollectionReport(int month, int year)
        {
            var data = await context.Payments.AsNoTracking()
                        .Include(x => x.Room)
                        .Include(x => x.BookingMaster).ThenInclude(g => g!.Guest)
                        .Where(x => x.HotelID == HotelID && x.PaymentDate.Month == month && x.PaymentDate.Year == year)
                        .OrderBy(x => x.PaymentDate)
                        .Select(x => new
                        {
                            x.PaymentDate.Date.Day,
                            x.AmountPaid,
                            x.Room!.RoomNumber,
                            x.Room.RoomTitle,
                            x.BookingMaster!.InvoiceNumber,
                            x.BookingMaster!.Guest!.FirstName
                        }).ToListAsync();

            var paymentDetail = data.GroupBy(x => x.Day)
                               .Select(x => new PaymentCollectionReportDetailDto
                               {
                                   TitleDate = $"Date: {x.Key}",
                                   DateTotal = x.Select(x => x.AmountPaid).Sum(),
                                   DateTable = x.Select(p => new PaymentCollectionReportDateWiseList
                                   {
                                       GuestName = p.FirstName,
                                       InvoiceNumber = p.InvoiceNumber,
                                       PaymentAmount = p.AmountPaid,
                                       RoomNumber = p.RoomNumber,
                                       RoomTitle = p.RoomTitle,
                                   }).ToList(),
                               }).ToList();

            PaymentCollectionReportDto result = new PaymentCollectionReportDto
            {
                HotelName = "Hotel Comfort",
                ReportTitle = $"Payment Collection Report - {month} - {year}",
                ReportTotal = data.Select(x => x.AmountPaid).Sum(),
                paymentCollectionReportDetails = paymentDetail
            };
            return result;
        }

        public async Task<bool> EditInvoiceMaster(BillingDto data)
        {
            var invoice = context.BookingMasters.FirstOrDefault(x => x.ID == data.ID);
            if (invoice == null) throw new Exception("invoice not found or deleted");

            if (invoice.InvoiceNumber != data.InvoiceNumber)
            {
                bool otherInvoicewithSameNumber = context.BookingMasters
                    .Any(x => x.InvoiceNumber!.ToLower().Trim() == data.InvoiceNumber!.ToLower().Trim() && x.ID != invoice.ID);

                if (otherInvoicewithSameNumber)
                    throw new Exception("Duplicate invoice number not allow");
            }

            invoice.InvoiceNumber = data.InvoiceNumber;
            invoice.InvoiceDate = data.BillDate;
            invoice.Discount = data.Discount;
            invoice.GuestID = data.GuestID;
            invoice.GuestStateCode = data.GuestStateCode;
            invoice.InputTaxCredit = data.InputTaxCredit;
            invoice.IsGSTApplicable = data.IsGSTApplicable;
            invoice.IsTaxInclusive = data.IsTaxInclusive;

            context.Update(invoice);
            await context.SaveChangesAsync();
            return true;
        }
    }

    public class GuestStateCode
    {
        public int GuestID { get; set; }
        public string? State { get; set; }
        public string? StateCode { get; set; }
    }
}
