using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<PagedList<Product>> GetAllProductsAsync(ProductParameters parameters, bool trackChanges);
        Task<Product> GetProductAsync(int id, bool trackChanges);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Product product);
    }
}
