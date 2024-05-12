using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.ProductRoomDto
{
    public abstract record ProductRoomDtoForManipulation
    {
        [Required]
        public int? ProductId { get; init; }
    }
}
