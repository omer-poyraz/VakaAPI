using Entities.Models;

namespace Entities.DTOs.StructureDto
{
    public record StructureDto
    {
        public int StructureId { get; init; }
        public string? StructureName { get; init; }
        public ICollection<WorkOrder>? WorkOrder { get; init; }
        public ICollection<Room>? Rooms { get; init; }
        public ICollection<Store>? Store { get; init; }
    }
}
