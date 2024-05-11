using Entities.Models;

namespace Entities.DTOs.WorkOrderDto
{
    public record WorkOrderDto
    {
        public int WorkOrderId { get; init; }
        public string? WorkOrderName { get; init; }
        public bool IsCompleted { get; init; }
        public int ProductId { get; init; }
        public Product? Product { get; init; }
        public int StructureId { get; init; }
        public Structure? Structure { get; init; }
        public int RoomId { get; init; }
        public Room? Room { get; init; }
        public int StoreId { get; init; }
        public Store? Store { get; init; }
    }
}
