using Entities.DTOs.RoomDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IRoomService
    {
        Task<(IEnumerable<RoomDto> roomDto, MetaData metaData)> GetAllProductsAsync(RoomParameters parameters, bool trackChanges);
        Task<IEnumerable<RoomDto>> GetAllByStructureAsync(int structureId, bool trackChanges);
        Task<RoomDto> GetRoomAsync(int id, bool trackChanges);
        Task<RoomDto> CreateRoomAsync(RoomDtoForInsertion roomDto);
        Task<RoomDto> UpdateRoomAsync(int id, RoomDtoForUpdate roomDto, bool trackChanges);
        Task<RoomDto> DeleteRoomAsync(int id, bool trackChanges);
    }
}
