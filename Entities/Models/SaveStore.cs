using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SaveStore
    {
        public int SaveStoreId { get; set; }
        [ForeignKey("StoreId")]
        public Store? Store { get; set; }
        public int? StoreId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int? ProductId { get; set; }
        public bool IsEntrance { get; set; }
        [ForeignKey("StructureId")]
        public Room? Room { get; set; }
        public int? RoomId { get; set; }
        [ForeignKey("StructureId")]
        public Structure? Structure { get; set; }
        public int? StructureId { get; set; }
        public DateTime CreateAt { get; set; }

        public SaveStore()
        {
            CreateAt = DateTime.Now;
        }
    }
}
