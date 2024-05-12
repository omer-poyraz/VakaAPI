using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.ProductStoreDto
{
    public abstract record ProductStoreDtoForManipulation
    {
        [Required]
        public int? ProductId { get; init; }
    }
}
