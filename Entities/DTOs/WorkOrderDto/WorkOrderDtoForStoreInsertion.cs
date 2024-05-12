using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDtoForStoreInsertion : WorkOrderDtoForManipulation
    {
        [Required]
        public int StoreId { get; init; }
    }
}
