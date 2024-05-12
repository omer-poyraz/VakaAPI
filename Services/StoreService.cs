using AutoMapper;
using Entities.DTOs.StoreDto;
using Entities.Exceptions.Store;
using Entities.Models;
using Entities.RequestFeature;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class StoreService : IStoreService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public StoreService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StoreDto> CreateStoreAsync(StoreDtoForInsertion storeDto)
        {
            var store = _mapper.Map<Store>(storeDto);
            _manager.StoreRepository.CreateStore(store);
            await _manager.SaveAsync();
            return _mapper.Map<StoreDto>(store);
        }

        public async Task<StoreDto> DeleteStoreAsync(int id, bool trackChanges)
        {
            var store = await CheckExists(id, trackChanges);
            _manager.StoreRepository.DeleteStore(store);
            await _manager.SaveAsync();
            return _mapper.Map<StoreDto>(store);
        }

        public async Task<(IEnumerable<StoreDto> storeDtos, MetaData metaData)> GetAllStoresAsync(StoreParameters parameters, bool trackChanges)
        {
            var stores = await _manager.StoreRepository.GetAllStoresAsync(parameters, trackChanges);
            var storeDto = _mapper.Map<IEnumerable<StoreDto>>(stores);
            return (storeDto, stores.MetaData);
        }

        public async Task<IEnumerable<StoreDto>> GetAllStoresByStructureAsync(int structureId, bool trackChanges)
        {
            var store = await _manager.StoreRepository.GetAllStoresByStructureAsync(structureId, trackChanges);
            return _mapper.Map<IEnumerable<StoreDto>>(store);
        }

        public async Task<StoreDto> GetStoreAsync(int id, bool trackChanges)
        {
            var store = await CheckExists(id, trackChanges);
            return _mapper.Map<StoreDto>(store);
        }

        public async Task<StoreDto> UpdateStoreAsync(int id, StoreDtoForUpdate storeDto, bool trackChanges)
        {
            var store = await CheckExists(id, trackChanges);
            store = _mapper.Map<Store>(storeDto);
            _manager.StoreRepository.UpdateStore(store);
            await _manager.SaveAsync();
            return _mapper.Map<StoreDto>(store);
        }
        private async Task<Store> CheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.StoreRepository.GetStoreAsync(id, trackChanges);
            if (entity is null)
            {
                _logger.LogError($"{id} number Id not found exception!");
                throw new StoreNotFoundException(id);
            }
            return entity;
        }
    }
}
