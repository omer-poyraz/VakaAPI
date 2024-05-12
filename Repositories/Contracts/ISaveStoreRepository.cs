using Entities.Models;

namespace Repositories.Contracts
{
    public interface ISaveStoreRepository : IRepositoryBase<SaveStore>
    {
        Task<IEnumerable<SaveStore>> GetAllSaveStoreAsync(bool trackChanges);
        Task<SaveStore> GetSaveStoreAsync(int id, bool trackChanges);
        SaveStore CreateSaveStore(SaveStore saveStore);
        SaveStore UpdateSaveStore(SaveStore saveStore);
        SaveStore DeleteSaveStore(SaveStore saveStore);
    }
}
