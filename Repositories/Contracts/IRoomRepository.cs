using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IRoomRepository : IRepositoryBase<Room>
    {
        Task<PagedList<Room>> GetAllRoomsAsync(RoomParameters parameters, bool trackChanges);
        Task<IEnumerable<Room>> GetAllByStructureAsync(int structureId, bool trackChanges);
        Task<Room> GetRoomAsync(int id, bool trackChanges);
        Room CreateRoom(Room room);
        Room UpdateRoom(Room room);
        Room DeleteRoom(Room room);
    }
}
