using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductStore
    {
        public int ProductStoreId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int? ProductId { get; set; }
    }
}
