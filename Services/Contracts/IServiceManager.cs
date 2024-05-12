namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IUserService UserService { get; }
        ILoggerService LoggerService { get; }
        IProductService ProductService { get; }
        IRoomService RoomService { get; }
        IStoreService StoreService { get; }
        IStructureService StructureService { get; }
        IWorkOrderService WorkOrderService { get; }
        IProductRoomService ProductRoomService { get; }
        IProductStoreService ProductStoreService { get; }
        ISaveStoreService SaveStoreService { get; }
    }
}
