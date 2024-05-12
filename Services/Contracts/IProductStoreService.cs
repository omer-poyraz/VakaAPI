using Entities.DTOs.ProductStoreDto;

namespace Services.Contracts
{
    public interface IProductStoreService
    {
        Task<IEnumerable<ProductStoreDto>> GetAllProductStoreAsync(bool trackChanges);
        Task<ProductStoreDto> GetProductStoreAsync(int id, bool trackChanges);
        Task<ProductStoreDto> CreateProductStoreAsync(ProductStoreDtoForInsertion productStoreDtoForInsertion);
        Task<ProductStoreDto> DeleteProductStoreAsync(int id, bool trackChanges);
    }
}
