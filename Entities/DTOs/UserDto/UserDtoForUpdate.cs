using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.UserDto
{
    public record UserDtoForUpdate : UserDtoForManipulation
    {
        [Required]
        public int UserId { get; init; }
    }
}
