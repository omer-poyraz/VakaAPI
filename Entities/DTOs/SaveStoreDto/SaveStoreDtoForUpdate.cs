using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.SaveStoreDto
{
    public record SaveStoreDtoForUpdate : SaveStoreDtoForManipulation
    {
        [Required]
        public int SaveStoreId { get; init; }
    }
}
