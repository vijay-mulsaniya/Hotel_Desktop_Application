namespace Hotel.Models
{
    public enum RoomType
    {
        Dormitory = 0,
        Standard = 1,
        Deluxe = 2,
        SuperDeluxe = 3,
        Luxery = 4
    }
    public enum Gender
    {
        Female = 0,
        Male = 1,
        Other = 2
    }
    public enum UserRole
    {
        SuperAdmin = 0,
        Admin = 1,
        Receptionist = 2,
        Housekeeping = 3,
        Guest = 4
    }
    public enum CleaningStatus
    {
        Pending = 0,
        Scheduled = 1,
        InProgress = 2,
        Completed = 3,
        Skipped = 4,
        Cancelled = 5
    }
    public enum CleaningType
    {
        Standard = 0,
        Deep = 1,
        Turnover = 2,
        Inspection = 3,
        Sanitization = 4
    }
    public enum PaymentMethod
    {
        Cash = 1,
        CreditCard = 2,
        DebitCard = 3,
        OnlinePayment = 4
    }

    public enum BookingStatus
    {
        Booked = 1,
        CheckedIn = 2,
        CheckedOut = 3,
        Cancelled = 4
    }
    public enum OccupancyStatus
    {
        Vacant = 1,
        Occupied = 2,
        Reserved = 3,
        OutOfService = 4
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Completed = 2,
        Failed = 3,
        Refunded = 4
    }
    public enum RoomService
    {
        Food = 1,
        Laundry = 2,
        Cleaning = 3,
        Spa = 4
    }
    public enum ReservationType
    {
        Online = 1,
        WalkIn = 2,
        Phone = 3,
        Agent = 4
    }
    public enum CancellationReason
    {
        Personal = 1,
        Weather = 2,
        Health = 3,
        Other = 4
    }
    public enum Season
    {
        Low = 1,
        Mid = 2,
        High = 3,
        Peak = 4
    }
    public enum DiscountType
    {
        Percentage = 1,
        FixedAmount = 2,
        Seasonal = 3,
        Promotional = 4
    }
    public enum TaxType
    {
        ServiceTax = 1,
        LuxuryTax = 2,
        TourismTax = 3,
        GST = 4
    }

    //public enum Amenity
    //{
    //    WiFi = 1,
    //    TV = 2,
    //    AirConditioning = 3,
    //    MiniBar = 4,
    //    Gym = 5,
    //    Pool = 6
    //}
}
