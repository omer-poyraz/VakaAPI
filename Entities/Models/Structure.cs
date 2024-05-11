using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Structure
    {
        public int StructureId { get; set; }
        public string? StructureName { get; set; }
        public ICollection<WorkOrder>? WorkOrder { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Store>? Store { get; set; }
    }
}
