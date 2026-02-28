using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hotel.Dtos
{
    public class DateWiseRoomViewDto
    {
        public List<DateWiseRowDto> dateWiseRowDtos { get; set; } = new List<DateWiseRowDto>();
    }

    public class DateWiseRowDto
    {
        public RoomBoxDto RoomBox { get; set; } = null!;
        public List<DateBoxDto> DateBoxes { get; set; } = new List<DateBoxDto>();
    }

    public class DateBoxDto
    {
        public int RoomId { get; set; }
        public string DateLabel { get; set; } = null!;
        public string MonthLabel { get; set; } = null!;
        public bool IsBooked { get; set; }
        public bool IsCheckOut { get; set; }
        public Color BackgoundColor
        {
            //get => IsBooked ? Color.LightGray 
            //                :  DateLabel == DateTime.Now.Day.ToString() 
            //                   ? Color.Green 
            //                   : Color.LightGreen;

            get => setBk(IsBooked, DateLabel, IsCheckOut);
        }
        public string? GuestName { get; set; }
        public DateTime? BoxDate { get; set; }

        private Color setBk(bool isBooked, string DateLabel, bool isCheckOut)
        {
            int boxDate = Convert.ToInt32(DateLabel);
            int toDayDay = DateTime.Now.Day;

            Color boxColor = Color.LimeGreen;

            if (boxDate == toDayDay)
                boxColor = Color.Green;

            if (isBooked)
                boxColor = Color.LightGray;

            if (isBooked && isCheckOut)
                boxColor = Color.Pink;

            return boxColor;
        }
    }

    public class RoomBoxDto
    {
        public int RoomId { get; set; }
        public string Number { get; set; } = null!;
        public string Title { get; set; } = null!;

    }

    public class BokkingDatesDto
    {
        public int RoomId { get; set; }
        public DateTime? BookedDate { get; set; }
        public string? GuestName { get; set; }
        public bool IsCheckOut { get; set; }
    }
}
