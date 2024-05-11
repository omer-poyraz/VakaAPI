namespace Entities.DTOs.StoreDto
{
    public abstract record StoreDtoForManipulation
    {
        public string? StoreName { get; init; }
        public int StructureId { get; init; }
    }
}
