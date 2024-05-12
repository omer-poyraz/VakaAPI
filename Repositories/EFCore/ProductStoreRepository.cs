using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProductStoreRepository : RepositoryBase<ProductStore>, IProductStoreRepository
    {
        public ProductStoreRepository(RepositoryContext context) : base(context)
        {
        }

        public ProductStore CreateProductStore(ProductStore productStore)
        {
            Create(productStore);
            return productStore;
        }

        public ProductStore DeleteProductStore(ProductStore productStore)
        {
            Delete(productStore);
            return productStore;
        }

        public async Task<IEnumerable<ProductStore>> GetAllProductStoreAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(p => p.ProductStoreId).Include(p => p.Product).ToListAsync();

        public async Task<ProductStore> GetProductStoreAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.ProductStoreId.Equals(id), trackChanges).Include(p => p.Product).SingleOrDefaultAsync();
    }
}
