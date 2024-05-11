using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public string? WorkOrderName { get; set; }
        public bool IsCompleted { get; set; }
        public int ProductId { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Product? Product { get; set; }
        public int StructureId { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Structure? Structure { get; set; }
        public int RoomId { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Room? Room { get; set; }
        public int StoreId { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Store? Store { get; set; }
    }
}
