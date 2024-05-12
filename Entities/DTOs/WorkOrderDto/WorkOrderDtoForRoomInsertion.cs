using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDtoForRoomInsertion : WorkOrderDtoForManipulation
    {
        [Required]
        public int RoomId { get; init; }
    }
}
