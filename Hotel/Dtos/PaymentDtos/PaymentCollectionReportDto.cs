using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Dtos.PaymentDtos
{
    public class PaymentCollectionReportDto
    {
        public string HotelName { get; set; } = string.Empty;
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? ReportTitle { get; set; }
        public List<PaymentCollectionReportDetailDto> paymentCollectionReportDetails { get; set; } = [];
        public decimal ReportTotal { get; set; }
    }
    public class PaymentCollectionReportDetailDto
    {
        public string? TitleDate { get; set; }
        public decimal? DateTotal { get; set; }
        public List<PaymentCollectionReportDateWiseList> DateTable { get; set; } = [];
    }
    public class PaymentCollectionReportDateWiseList
    {
        public string? GuestName { get; set; }
        public string? RoomNumber { get; set; }
        public string? RoomTitle { get; set; }
        public string? InvoiceNumber { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
