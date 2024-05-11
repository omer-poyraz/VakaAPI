using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDtoForUpdate : WorkOrderDtoForManipulation
    {
        [Required]
        public int WorkOrderId { get; set; }
    }
}
