using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class RoomRepository : RepositoryBase<Room>, IRoomRepository
    {
        public RoomRepository(RepositoryContext context) : base(context)
        {
        }

        public Room CreateRoom(Room room)
        {
            Create(room);
            return room;
        }

        public Room DeleteRoom(Room room)
        {
            Delete(room);
            return room;
        }

        public async Task<PagedList<Room>> GetAllRoomsAsync(RoomParameters parameters, bool trackChanges)
        {
            var rooms = await FindAll(trackChanges)
                .OrderBy(r => r.RoomId)
                .Include(r => r.WorkOrders)
                .Include(r => r.Structure)
                .Include(r => r.Products)
                .SearchRoom(parameters.SearchTerm!)
                .ToListAsync();

            return PagedList<Room>.ToPagedList(rooms, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Room> GetRoomAsync(int id, bool trackChanges) =>
            await FindByCondition(r => r.RoomId.Equals(id), trackChanges)
            .Include(r => r.WorkOrders)
            .Include(r => r.Structure)
            .Include(r => r.Products)
            .SingleOrDefaultAsync();

        public Room UpdateRoom(Room room)
        {
            Update(room);
            return room;
        }
    }
}
