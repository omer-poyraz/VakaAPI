namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int StoreId { get; set; }
        public bool IsExit { get; set; }
        public int RoomId { get; set; }
        public ICollection<WorkOrder>? WorkOrder { get; set; }
        public Room? Room { get; set; }
        public Store? Store { get; set; }
    }
}
