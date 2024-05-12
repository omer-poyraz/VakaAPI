using Entities.DTOs.ProductRoomDto;

namespace Services.Contracts
{
    public interface IProductRoomService
    {
        Task<IEnumerable<ProductRoomDto>> GetAllProductRoomAsync(bool trackChanges);
        Task<ProductRoomDto> GetProductRoomAsync(int id, bool trackChanges);
        Task<ProductRoomDto> CreateProductRoomAsync(ProductRoomDtoForInsertion productRoomDto);
        Task<ProductRoomDto> DeleteProductRoomAsync(int id, bool trackChanges);
    }
}
