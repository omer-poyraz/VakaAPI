using AutoMapper;
using Entities.DTOs.ProductRoomDto;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductRoomService : IProductRoomService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public ProductRoomService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ProductRoomDto> CreateProductRoomAsync(ProductRoomDtoForInsertion productRoomDto)
        {
            var product = _mapper.Map<ProductRoom>(productRoomDto);
            _manager.ProductRoomRepository.CreateProductRoom(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductRoomDto>(product);
        }

        public async Task<ProductRoomDto> DeleteProductRoomAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductRoomRepository.GetProductRoomAsync(id, trackChanges);
            _manager.ProductRoomRepository.DeleteProductRoom(product);
            await _manager.SaveAsync();
            return _mapper.Map<ProductRoomDto>(product);
        }

        public async Task<IEnumerable<ProductRoomDto>> GetAllProductRoomAsync(bool trackChanges)
        {
            var products = await _manager.ProductRoomRepository.GetAllProductRoomAsync(trackChanges);
            return _mapper.Map<IEnumerable<ProductRoomDto>>(products);
        }

        public async Task<ProductRoomDto> GetProductRoomAsync(int id, bool trackChanges)
        {
            var product = await _manager.ProductRoomRepository.GetProductRoomAsync(id, trackChanges);
            return _mapper.Map<ProductRoomDto>(product);
        }
    }
}
