namespace Entities.DTOs.ProductDto
{
    public abstract record ProductDtoForManipulation
    {
        public string? ProductName { get; init; }
    }
}
