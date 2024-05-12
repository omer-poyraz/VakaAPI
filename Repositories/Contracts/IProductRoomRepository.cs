using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRoomRepository : IRepositoryBase<ProductRoom>
    {
        Task<IEnumerable<ProductRoom>> GetAllProductRoomAsync(bool trackChanges);
        Task<ProductRoom> GetProductRoomAsync(int id, bool trackChanges);
        ProductRoom CreateProductRoom(ProductRoom productRoom);
        ProductRoom DeleteProductRoom(ProductRoom productRoom);
    }
}
