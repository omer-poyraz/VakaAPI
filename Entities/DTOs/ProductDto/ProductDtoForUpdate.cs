using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.ProductDto
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [Required]
        public int ProductId { get; init; }
    }
}
