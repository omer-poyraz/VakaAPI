using AutoMapper;
using Entities.DTOs.ProductDto;
using Entities.Exceptions.Product;
using Entities.Models;
using Entities.RequestFeature;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDtoForInsertion productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _manager.ProductRepository.CreateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> DeleteProductAsync(int id, bool trackChanges)
        {
            var product = await CheckExists(id, trackChanges);
            _manager.ProductRepository.DeleteProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<(IEnumerable<ProductDto> dtos, MetaData metaData)> GetAllProductsAsync(ProductParameters parameters, bool trackChanges)
        {
            var products = await _manager.ProductRepository.GetAllProductsAsync(parameters, trackChanges);
            var productDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            return (productDto, products.MetaData);
        }

        public async Task<ProductDto> GetProductAsync(int id, bool trackChanges)
        {
            var product = await CheckExists(id, trackChanges);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProductAsync(int id, ProductDtoForUpdate productDto, bool trackChanges)
        {
            var product = await CheckExists(id, trackChanges);
            product = _mapper.Map<Product>(productDto);
            _manager.ProductRepository.UpdateProduct(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductDto>(product);
        }

        private async Task<Product> CheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.ProductRepository.GetProductAsync(id, trackChanges);
            if (entity is null)
            {
                _logger.LogError($"{id} number Id not found exception!");
                throw new ProductNotFoundException(id);
            }
            return entity;
        }
    }
}
