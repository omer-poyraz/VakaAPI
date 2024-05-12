using Entities.DTOs.StoreDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IStoreService
    {
        Task<(IEnumerable<StoreDto> storeDtos, MetaData metaData)> GetAllStoresAsync(StoreParameters parameters, bool trackChanges);
        Task<IEnumerable<StoreDto>> GetAllStoresByStructureAsync(int structureId, bool trackChanges);
        Task<StoreDto> GetStoreAsync(int id, bool trackChanges);
        Task<StoreDto> CreateStoreAsync(StoreDtoForInsertion storeDto);
        Task<StoreDto> UpdateStoreAsync(int id, StoreDtoForUpdate storeDto, bool trackChanges);
        Task<StoreDto> DeleteStoreAsync(int id, bool trackChanges);
    }
}
