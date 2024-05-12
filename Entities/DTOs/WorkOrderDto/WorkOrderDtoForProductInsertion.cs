using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDtoForProductInsertion : WorkOrderDtoForManipulation
    {
        [Required]
        public int ProductId { get; init; }
    }
}
