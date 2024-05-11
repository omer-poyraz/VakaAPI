using Entities.Models;

namespace Entities.DTOs.ProductDto
{
    public record ProductDto
    {
        public int ProductId { get; init; }
        public string? ProductName { get; init; }
        public int StoreId { get; init; }
        public bool IsExit { get; init; }
        public int RoomId { get; init; }
        public ICollection<WorkOrder>? WorkOrder { get; init; }
        public Room? Room { get; init; }
        public Store? Store { get; init; }
    }
}
