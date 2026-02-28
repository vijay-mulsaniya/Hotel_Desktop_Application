namespace Hotel.Dtos
{
    public class RoomStatusAllDto
    {
        public string Daytype
        {
            get
            {
                string daytype = SelectedDate.ToString("D");
                DateTime today = DateTime.Today;
                if (SelectedDate.Date == today)
                    daytype = "Today";
                else if (SelectedDate.Date == today.AddDays(-1))
                    daytype = "Yesterday";
                else if (SelectedDate.Date == today.AddDays(1))
                    daytype = "Tomorrow";
                return daytype;
            }
        } // Today, Yesterday, Tomorrow.
        public DateTime SelectedDate { get; set; }
        public int BookedRooms { get; set; }
        public int AvailableRooms { get; set; }
        public int TotalRooms => BookedRooms + AvailableRooms;
        public List<TitleCountDto> RoomStatusByTitle { get; set; } = new List<TitleCountDto>();
        public List<BookedRoomDto> RoomList { get; set; } = new List<BookedRoomDto>();
    }

    public class TitleCountDto
    {
        public string Title { get; set; } = string.Empty;
        public int BookedCount { get; set; }
        public int AvailableCount { get; set; }
        public int TotalCount => BookedCount + AvailableCount;
    }
    public class RoomDto
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomTitle { get; set; }
        public string? RoomType { get; set; }
        public string? Description { get; set; }
        public int Capacity { get; set; }
        public int Charges { get; set; }
        public bool IsClean { get; set; }
        public bool IsAvailable { get; set; }
    }
    public class BookedRoomDto : RoomDto
    {
        public string? GuestName { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public bool IsCouple { get; set; } = false;
        public int Adults { get; set; }
        public int Children { get; set; }
        public string PersonCount { get; set; } = string.Empty;
        public int Nights { get; set; }
        public decimal FoodCharges { get; set; } = 0;
        public decimal TotalCharges { get; set; } = 0;
        public decimal PaidAmount { get; set; } = 0;
        public int BookingMasterId { get; set; }
        public decimal DueAmount => TotalCharges - PaidAmount + FoodCharges;
        public bool IsCheckOutCard { get; set; }
        public bool IsDirty { get; set; }
        public bool IsLateCheckout { get; set; }
        public bool IsAvailableRoomLevel { get; set; }
        public int OverStayDays { get; set; }
    }
}
