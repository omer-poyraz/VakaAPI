using Entities.DTOs.ProductDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IProductService
    {
        Task<(IEnumerable<ProductDto> dtos, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool trackChanges);
        Task<ProductDto> GetProductAsync(int id, bool trackChanges);
        Task<ProductDto> CreateProductAsync(ProductDtoForInsertion productDto);
        Task<ProductDto> UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges);
        Task<ProductDto> DeleteProductAsync(int id, bool trackChanges);
    }
}
