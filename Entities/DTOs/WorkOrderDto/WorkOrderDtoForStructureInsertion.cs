using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDtoForStructureInsertion : WorkOrderDtoForManipulation
    {
        [Required]
        public int StructureId { get; init; }
    }
}
