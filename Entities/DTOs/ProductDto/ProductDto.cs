using Entities.Models;

namespace Entities.DTOs.ProductDto
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        public string? ProductName { get; init; }
        public ICollection<WorkOrder>? WorkOrder { get; init; }
    }
}
