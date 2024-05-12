using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class ProductRoomRepository : RepositoryBase<ProductRoom>, IProductRoomRepository
    {
        public ProductRoomRepository(RepositoryContext context) : base(context)
        {
        }

        public ProductRoom CreateProductRoom(ProductRoom productRoom)
        {
            Create(productRoom);
            return productRoom;
        }

        public ProductRoom DeleteProductRoom(ProductRoom productRoom)
        {
            Delete(productRoom);
            return productRoom;
        }

        public async Task<IEnumerable<ProductRoom>> GetAllProductRoomAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(p => p.ProductRoomId).Include(p => p.Product).ToListAsync();

        public async Task<ProductRoom> GetProductRoomAsync(int id, bool trackChanges) =>
            await FindByCondition(p => p.ProductRoomId.Equals(id), trackChanges).Include(p => p.ProductRoomId).SingleOrDefaultAsync();
    }
}
