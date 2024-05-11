using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public abstract record WorkOrderDtoForManipulation
    {
        [Required]
        public string? WorkOrderName { get; init; }
        public bool IsCompleted { get; init; }
        public int ProductId { get; init; }
        public int StructureId { get; init; }
        public int RoomId { get; init; }
        public int StoreId { get; init; }
    }
}
