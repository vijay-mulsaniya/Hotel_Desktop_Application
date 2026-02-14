using Hotel.Common;

namespace Hotel.Dtos.AuthDtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string HotelName { get; set; } = null!;
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AvatarUrl { get; set; }
        public string? MobileNumber1 { get; set; }
        public string? MobileNumber2 { get; set; }
        public string? LoginToken { get; set; }

        public DateTime? CreatedOn { get; set; } 
        public int? CreatedbyId { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedbyId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public RoleDto? Role { get; set; }
    }
}
