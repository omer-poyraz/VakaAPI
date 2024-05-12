using Entities.Models;

namespace Entities.DTOs.SaveStoreDto
{
    public abstract record SaveStoreDtoForManipulation
    {
        public int? StoreId { get; init; }
        public int? ProductId { get; init; }
        public bool IsEntrance { get; init; }
        public int? RoomId { get; init; }
        public int? StructureId { get; init; }
    }
}
