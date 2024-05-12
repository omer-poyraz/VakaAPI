using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string? StoreName { get; set; }
        public ICollection<WorkOrder>? WorkOrder { get; set; }
        [ForeignKey("StructureId")]
        public Structure? Structure { get; set; }
        public int? StructureId { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
