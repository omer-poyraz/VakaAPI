using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string? RoomName { get; set; }
        public ICollection<WorkOrder>? WorkOrders { get; set; }
        [ForeignKey("StructureId")]
        public Structure? Structure { get; set; }
        public int? StructureId { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
