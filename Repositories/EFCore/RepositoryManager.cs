using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IStructureRepository _structureRepository;
        private readonly IWorkOrderRepository _workOrderRepository;
        private readonly IProductStoreRepository _productStoreRepository;
        private readonly IProductRoomRepository _productRoomRepository;
        private readonly ISaveStoreRepository _saveStoreRepository;

        public RepositoryManager(RepositoryContext context, IUserRepository userRepository, IProductRepository productRepository, IRoomRepository roomRepository, IStoreRepository storeRepository, IStructureRepository structureRepository, IWorkOrderRepository workOrderRepository, IProductStoreRepository productStoreRepository, IProductRoomRepository productRoomRepository, ISaveStoreRepository saveStoreRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _roomRepository = roomRepository;
            _storeRepository = storeRepository;
            _structureRepository = structureRepository;
            _workOrderRepository = workOrderRepository;
            _productStoreRepository = productStoreRepository;
            _productRoomRepository = productRoomRepository;
            _saveStoreRepository = saveStoreRepository;
        }

        public IUserRepository UserRepository => _userRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IRoomRepository RoomRepository => _roomRepository;
        public IStoreRepository StoreRepository => _storeRepository;
        public IStructureRepository StructureRepository => _structureRepository;
        public IWorkOrderRepository WorkOrderRepository => _workOrderRepository;
        public IProductStoreRepository ProductStoreRepository => _productStoreRepository;
        public IProductRoomRepository ProductRoomRepository => _productRoomRepository;
        public ISaveStoreRepository SaveStoreRepository => _saveStoreRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
