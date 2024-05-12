using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class SaveStoreRepository : RepositoryBase<SaveStore>, ISaveStoreRepository
    {
        public SaveStoreRepository(RepositoryContext context) : base(context)
        {
        }

        public SaveStore CreateSaveStore(SaveStore saveStore)
        {
            Create(saveStore);
            return saveStore;
        }

        public SaveStore DeleteSaveStore(SaveStore saveStore)
        {
            Delete(saveStore);
            return saveStore;
        }

        public async Task<IEnumerable<SaveStore>> GetAllSaveStoreAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(s => s.SaveStoreId)
            .Include(s => s.Structure)
            .Include(s => s.Product)
            .Include(s => s.Room)
            .Include(s => s.Store)
            .ToListAsync();

        public async Task<SaveStore> GetSaveStoreAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.SaveStoreId.Equals(id), trackChanges)
            .Include(s => s.Structure)
            .Include(s => s.Product)
            .Include(s => s.Room)
            .Include(s => s.Store)
            .SingleOrDefaultAsync();

        public SaveStore UpdateSaveStore(SaveStore saveStore)
        {
            Update(saveStore);
            return saveStore;
        }
    }
}
