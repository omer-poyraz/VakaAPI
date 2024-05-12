using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class WorkOrder
    {
        public int WorkOrderId { get; set; }
        public string? WorkOrderName { get; set; }
        public bool IsCompleted { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("StructureId")]
        public Structure? Structure { get; set; }
        public int? StructureId { get; set; }
        [ForeignKey("RoomId")]
        public Room? Room { get; set; }
        public int? RoomId { get; set; }
        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
        public int? StoreId { get; set; }
    }
}
