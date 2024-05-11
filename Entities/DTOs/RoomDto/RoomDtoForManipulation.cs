namespace Entities.DTOs.RoomDto
{
    public abstract record RoomDtoForManipulation
    {
        public string? RoomName { get; init; }
        public int StructureId { get; init; }
    }
}
