using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.RoomDto
{
    public record RoomDtoForUpdate : RoomDtoForManipulation
    {
        [Required]
        public int RoomId { get; init; }
    }
}
