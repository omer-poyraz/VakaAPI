using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductStoreRepository : IRepositoryBase<ProductStore>
    {
        Task<IEnumerable<ProductStore>> GetAllProductStoreAsync(bool trackChanges);
        Task<ProductStore> GetProductStoreAsync(int id, bool trackChanges);
        ProductStore CreateProductStore(ProductStore productStore);
        ProductStore DeleteProductStore(ProductStore productStore);
    }
}
