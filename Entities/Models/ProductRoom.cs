using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductRoom
    {
        public int ProductRoomId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int? ProductId { get; set; }
    }
}
