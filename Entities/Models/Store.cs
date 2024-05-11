using Microsoft.EntityFrameworkCore;

namespace Entities.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string? StoreName { get; set; }
        public int StructureId { get; set; }
        public ICollection<WorkOrder>? WorkOrder { get; set; }
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public Structure? Structure { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
