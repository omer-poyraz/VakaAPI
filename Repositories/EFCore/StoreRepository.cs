using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class StoreRepository : RepositoryBase<Store>, IStoreRepository
    {
        public StoreRepository(RepositoryContext context) : base(context)
        {
        }

        public Store CreateStore(Store store)
        {
            Create(store);
            return store;
        }

        public Store DeleteStore(Store store)
        {
            Delete(store);
            return store;
        }

        public async Task<PagedList<Store>> GetAllStoresAsync(StoreParameters parameters, bool trackChanges)
        {
            var stores = await FindAll(trackChanges)
                .OrderBy(s => s.StoreId)
                .Include(s => s.WorkOrder)
                .Include(s => s.Structure)
                .Include(s => s.Products)
                .SearchStore(parameters.SearchTerm!)
                .ToListAsync();

            return PagedList<Store>.ToPagedList(stores, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Store> GetStoreAsync(int id, bool trackChanges) =>
            await FindByCondition(s => s.StoreId.Equals(id), trackChanges)
            .Include(s => s.WorkOrder)
            .Include(s => s.Structure)
            .Include(s => s.Products)
            .SingleOrDefaultAsync();

        public Store UpdateStore(Store store)
        {
            Update(store);
            return store;
        }
    }
}
