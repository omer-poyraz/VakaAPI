using Entities.Models;

namespace Entities.DTOs.ProductStoreDto
{
    public record ProductStoreDto
    {
        public int ProductStoreId { get; init; }
        public Product? Product { get; init; }
        public int? ProductId { get; init; }
    }
}
