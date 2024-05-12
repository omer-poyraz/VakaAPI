using Entities.Models;

namespace Entities.DTOs.SaveStoreDto
{
    public record SaveStoreDto
    {
        public int SaveStoreId { get; init; }
        public Store? Store { get; init; }
        public int? StoreId { get; init; }
        public Product? Product { get; init; }
        public int? ProductId { get; init; }
        public bool IsEntrance { get; init; }
        public Room? Room { get; init; }
        public int? RoomId { get; init; }
        public Structure? Structure { get; init; }
        public int? StructureId { get; init; }
        public DateTime CreateAt { get; init; }
    }
}
