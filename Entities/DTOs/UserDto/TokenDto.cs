namespace Entities.DTOs.UserDto
{
    public record TokenDto
    {
        public int UserId { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
