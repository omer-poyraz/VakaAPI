using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public int StructureId { get; set; }
        public ICollection<WorkOrder>? WorkOrders { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Structure? Structure { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
