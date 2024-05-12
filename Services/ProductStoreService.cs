using AutoMapper;
using Entities.DTOs.ProductStoreDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductStoreService : IProductStoreService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ProductStoreService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProductStoreDto> CreateProductStoreAsync(ProductStoreDtoForInsertion productStoreDtoForInsertion)
        {
            var product = _mapper.Map<ProductStore>(productStoreDtoForInsertion);
            _manager.ProductStoreRepository.CreateProductStore(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductStoreDto>(product);
        }

        public async Task<ProductStoreDto> DeleteProductStoreAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductStoreRepository.GetProductStoreAsync(id, trackChanges);
            _manager.ProductStoreRepository.DeleteProductStore(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductStoreDto>(product);
        }

        public async Task<IEnumerable<ProductStoreDto>> GetAllProductStoreAsync(bool trackChanges)
        {
            var products = await _manager.ProductStoreRepository.GetAllProductStoreAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductStoreDto>>(products);
        }

        public async Task<ProductStoreDto> GetProductStoreAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductStoreRepository.GetProductStoreAsync(id, trackChanges);
            return _mapper.Map<ProductStoreDto>(product);
        }
    }
}
