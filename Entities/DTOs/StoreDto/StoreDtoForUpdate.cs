using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.StoreDto
{
    public record StoreDtoForUpdate : StoreDtoForManipulation
    {
        [Required]
        public int StoreId { get; init; }
    }
}
