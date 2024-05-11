using Entities.Models;

namespace Entities.DTOs.StoreDto
{
    public record StoreDto
    {
        public int StoreId { get; init; }
        public string? StoreName { get; init; }
        public int StructureId { get; init; }
        public ICollection<WorkOrder>? WorkOrder { get; init; }
        public Structure? Structure { get; init; }
        public ICollection<Product>? Products { get; init; }
    }
}
