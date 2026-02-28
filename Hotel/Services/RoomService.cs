using Hotel.Data;
using Hotel.Dtos;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Services
{
    public interface IRoomService
    {
        Task<AddNewBookingDto> AddNewBooking(AddNewBookingDto bookingDto);
        List<TblRoom> GetAvailableRooms(DateTime fromDate, DateTime toDate);
        void GenerateInvoiceNumber(int HotelId, out int currentNumber, out TblTransactionSequence? transactionSequence, out string invoiceNumber);
        Task<DateWiseRoomViewDto> dateWiseRoomView(DateTime fromDate, DateTime toDate);
    }

    public class RoomService : IRoomService
    {
        private readonly IRepository<TblBookingMaster> bookingMasterRepo;
        private readonly IRepository<TblRoomBooking> roomBookingRepo;
        private readonly IDbContextFactory<AppDbContext> factory;
        //private readonly AppDbContext context;
        private static int HotelID = 1;

        public RoomService(IRepository<TblBookingMaster> bookingMasterRepo, IRepository<TblRoomBooking> roomBookingRepo, IDbContextFactory<AppDbContext> factory)
        {
            this.bookingMasterRepo = bookingMasterRepo;
            this.roomBookingRepo = roomBookingRepo;
            this.factory = factory;
            //this.context = context;
        }
        public async Task<AddNewBookingDto> AddNewBooking(AddNewBookingDto bookingDto)
        {
            using var context = await factory.CreateDbContextAsync();
            await bookingMasterRepo.AddAsync(bookingDto.BookingMaster);
            var bookingMasterID = bookingDto.BookingMaster.ID;

            foreach (var roomBooking in bookingDto.RoomBookings)
            {
                roomBooking.BookingMasterID = bookingMasterID;
                await roomBookingRepo.AddAsync(roomBooking);
                var roomID = roomBooking.RoomID;
                var room = await context.Rooms.FindAsync(roomID);
                if (room != null)
                {
                    room.IsAvailable = false;
                    room.IsClean = false;
                    context.Rooms.Update(room);
                    await context.SaveChangesAsync();
                }
            }

            return bookingDto;
        }
        public List<TblRoom> GetAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            // checkout date (excluded)
            using var context = factory.CreateDbContext();
            var availableRooms = context.Rooms
                .Where(r => r.HotelID == 1)
                .Where(r => r.IsAvailable)
                .Where(r =>
                    !r.RoomBookings.Any(rb =>
                        rb.Status == BookingStatus.Booked &&
                        rb.Date.HasValue &&
                        rb.Date.Value >= fromDate &&
                        rb.Date.Value < toDate
                    )
                ).ToList();

            return availableRooms;
        }
        public void GenerateInvoiceNumber(int HotelId, out int currentNumber, out TblTransactionSequence? transactionSequence, out string invoiceNumber)
        {
            using var context = factory.CreateDbContext();
            transactionSequence = context.TransactionSequences.FirstOrDefault(x => x.HotelID == HotelId && x.TransactionTypeId == 1); //1 == Invoice
            if (transactionSequence == null || transactionSequence.LastNumber == 0)
            {
                transactionSequence = new TblTransactionSequence { HotelID = HotelId, TransactionTypeId = 1, LastNumber = 0 };
                context.TransactionSequences.Add(transactionSequence);
                currentNumber = 1;
            }
            else
                currentNumber = transactionSequence.LastNumber + 1;

            invoiceNumber = $"INV-{currentNumber:D5}";
        }
        public async Task<DateWiseRoomViewDto> dateWiseRoomView(DateTime fromDate, DateTime toDate)
        {
            using var context = await factory.CreateDbContextAsync();
            DateWiseRoomViewDto viewDto = new DateWiseRoomViewDto();
            var roomBoxes = await RoomBoxDtos();

            var bookings = await context.RoomBookings.AsNoTracking()
                                .Where(x => x.HotelID == HotelID &&
                                    x.Date.HasValue && x.Date.Value.Date >= fromDate.Date
                                    && x.Date.Value.Date <= toDate.Date && x.NightStay == true)
                                .Select(x => new BokkingDatesDto
                                {
                                    RoomId = x.RoomID,
                                    BookedDate = x.Date!.Value.Date,
                                    GuestName = x.Guest!.FirstName,
                                    IsCheckOut = x.IsCheckedOut
                                }).ToListAsync();

            foreach (var roomBox in roomBoxes)
            {
                var bookList = bookings.Where(x => x.RoomId == roomBox.RoomId).ToList();
                DateWiseRowDto dateWiseRowDto = new DateWiseRowDto();
                dateWiseRowDto.RoomBox = roomBox;
                dateWiseRowDto.DateBoxes = DateBoxes(roomBox.RoomId, bookList, fromDate, toDate);
                viewDto.dateWiseRowDtos.Add(dateWiseRowDto);
            }
            return viewDto;
        }
        public async Task<List<RoomBoxDto>> RoomBoxDtos()
        {
            using var context = await factory.CreateDbContextAsync();
            var roomBoxes = await context.Rooms.AsNoTracking().Select(x => new RoomBoxDto
            {
                RoomId = x.ID,
                Number = x.RoomNumber!,
                Title = x.RoomTitle!
            }).ToListAsync();
            return roomBoxes;
        }
        public List<DateBoxDto> DateBoxes(int roomId, List<BokkingDatesDto> bookings, DateTime fromDate, DateTime toDate)
        {
            List<DateBoxDto> dateBoxes = new List<DateBoxDto>();
            for (DateTime date = fromDate.Date; date <= toDate.Date; date = date.AddDays(1))
            {
                var isBooked = bookings.Any(x => x.BookedDate == date);
                var isCheckout = bookings.Any(x => x.BookedDate == date && x.IsCheckOut == true);
                DateBoxDto dateBoxDto = new DateBoxDto
                {
                    RoomId = roomId,
                    DateLabel = date.ToString("dd"),
                    MonthLabel = date.ToString("MM-yyyy"),
                    IsBooked = isBooked,
                    GuestName = isBooked ? bookings.FirstOrDefault(x => x.BookedDate == date)!.GuestName : null,
                    BoxDate = date,
                    IsCheckOut = isCheckout
                };
                dateBoxes.Add(dateBoxDto);
            }
            return dateBoxes;
        }
    }
}
