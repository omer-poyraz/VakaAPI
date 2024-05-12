using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public abstract record WorkOrderDtoForManipulation
    {
        [Required]
        public string? WorkOrderName { get; init; }
        public bool IsCompleted { get; init; }
    }
}
