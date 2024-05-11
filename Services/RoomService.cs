using AutoMapper;
using Entities.DTOs.RoomDto;
using Entities.Exceptions.Room;
using Entities.Models;
using Entities.RequestFeature;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public RoomService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<RoomDto> CreateRoomAsync(RoomDtoForInsertion roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _manager.RoomRepository.CreateRoom(room);
            await _manager.SaveAsync();
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> DeleteRoomAsync(int id, bool trackChanges)
        {
            var room = await CheckExists(id, trackChanges);
            _manager.RoomRepository.DeleteRoom(room);
            await _manager.SaveAsync();
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<(IEnumerable<RoomDto> roomDto, MetaData metaData)> GetAllProductsAsync(RoomParameters parameters, bool trackChanges)
        {
            var rooms = await _manager.RoomRepository.GetAllRoomsAsync(parameters, trackChanges);
            var roomDto = _mapper.Map<IEnumerable<RoomDto>>(rooms);
            return (roomDto, rooms.MetaData);
        }

        public async Task<RoomDto> GetRoomAsync(int id, bool trackChanges)
        {
            var room = await CheckExists(id, trackChanges);
            return _mapper.Map<RoomDto>(room);
        }

        public async Task<RoomDto> UpdateRoomAsync(int id, RoomDtoForUpdate roomDto, bool trackChanges)
        {
            var room = await CheckExists(id, trackChanges);
            room = _mapper.Map<Room>(roomDto);
            _manager.RoomRepository.UpdateRoom(room);
            await _manager.SaveAsync();
            return _mapper.Map<RoomDto>(room);
        }

        private async Task<Room> CheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.RoomRepository.GetRoomAsync(id, trackChanges);
            if (entity is null)
            {
                _logger.LogError($"{id} number Id not found exception!");
                throw new RoomNotFoundException(id);
            }
            return entity;
        }
    }
}
