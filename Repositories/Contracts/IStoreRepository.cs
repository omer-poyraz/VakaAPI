using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IStoreRepository : IRepositoryBase<Store>
    {
        Task<PagedList<Store>> GetAllStoresAsync(StoreParameters parameters, bool trackChanges);
        Task<IEnumerable<Store>> GetAllStoresByStructureAsync(int  structureId, bool trackChanges);
        Task<Store> GetStoreAsync(int id, bool trackChanges);
        Store CreateStore(Store store);
        Store UpdateStore(Store store);
        Store DeleteStore(Store store);
    }
}
