﻿namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        IRoomRepository RoomRepository { get; }
        IStoreRepository StoreRepository { get; }
        IStructureRepository StructureRepository { get; }
        IWorkOrderRepository WorkOrderRepository { get; }
        Task SaveAsync();
    }
}
