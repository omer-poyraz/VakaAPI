using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {
        }

        public Product CreateProduct(Product product)
        {
            Create(product);
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            Delete(product);
            return product;
        }

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters parameters, bool trackChanges)
        {
            var products = await FindAll(trackChanges)
                .OrderBy(p => p.ProductId)
                .Include(p => p.WorkOrder)
                .Include(p => p.Room)
                .Include(p => p.Store)
                .SearchProduct(parameters.SearchTerm!)
                .ToListAsync();

            return PagedList<Product>.ToPagedList(products, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Product> GetProductAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.ProductId.Equals(id), trackChanges)
            .Include(p => p.WorkOrder)
            .Include(p => p.Room)
            .Include(p => p.Store)
            .SingleOrDefaultAsync();

        public Product UpdateProduct(Product product)
        {
            Update(product);
            return product;
        }
    }
}
