using Entities.Models;

namespace Entities.DTOs.RoomDto
{
    public record RoomDto
    {
        public int RoomId { get; init; }
        public string? RoomName { get; init; }
        public int StructureId { get; init; }
        public ICollection<WorkOrder>? WorkOrders { get; init; }
        public Structure? Structure { get; init; }
        public ICollection<Product>? Products { get; init; }
    }
}
