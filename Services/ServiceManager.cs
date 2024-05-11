using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILoggerService _loggerService;
        private readonly IProductService _productService;
        private readonly IRoomService _roomService;
        private readonly IStoreService _storeService;
        private readonly IStructureService _structureService;
        private readonly IWorkOrderService _workOrderService;

        public ServiceManager(IAuthenticationService authenticationService, IUserService userService, ILoggerService loggerService, IProductService productService, IRoomService roomService, IStoreService storeService, IStructureService structureService, IWorkOrderService workOrderService)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _loggerService = loggerService;
            _productService = productService;
            _roomService = roomService;
            _storeService = storeService;
            _structureService = structureService;
            _workOrderService = workOrderService;
        }

        public IAuthenticationService AuthenticationService => _authenticationService;
        public IUserService UserService => _userService;
        public ILoggerService LoggerService => _loggerService;
        public IProductService ProductService => _productService;
        public IRoomService RoomService => _roomService;
        public IStoreService StoreService => _storeService;
        public IStructureService StructureService => _structureService;
        public IWorkOrderService WorkOrderService => _workOrderService;
    }
}
