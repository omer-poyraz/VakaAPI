namespace Entities.DTOs.ProductDto
{
    public abstract record ProductDtoForManipulation
    {
        public string? ProductName { get; init; }
        public int StoreId { get; init; }
        public bool IsExit { get; init; }
        public int RoomId { get; init; }
    }
}
