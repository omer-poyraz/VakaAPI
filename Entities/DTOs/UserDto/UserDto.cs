using Microsoft.AspNetCore.Identity;

namespace Entities.DTOs.UserDto
{
    public record UserDto
    {
        public int UserId { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? RefreshToken { get; init; }
        public DateTime RefreshTokenExpireTime { get; init; }
        public ICollection<IdentityRole>? Roles { get; init; }
    }
}
