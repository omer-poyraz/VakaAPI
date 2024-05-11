using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.StructureDto
{
    public record StructureDtoForUpdate : StructureDtoForManipulation
    {
        [Required]
        public int StructureId { get; init; }
    }
}
