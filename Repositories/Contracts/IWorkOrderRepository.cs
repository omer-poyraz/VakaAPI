using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IWorkOrderRepository : IRepositoryBase<WorkOrder>
    {
        Task<PagedList<WorkOrder>> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges);
        Task<IEnumerable<WorkOrder>> GetProductWorkOrderAsync(int productId, bool trackChanges);
        Task<IEnumerable<WorkOrder>> GetRoomWorkOrderAsync(int roomId, bool trackChanges);
        Task<IEnumerable<WorkOrder>> GetStoreWorkOrderAsync(int storeId, bool trackChanges);
        Task<IEnumerable<WorkOrder>> GetStructureWorkOrderAsync(int structureId, bool trackChanges);
        Task<WorkOrder> GetWorkOrderAsync(int id, bool trackChanges);
        WorkOrder CreateWorkOrder(WorkOrder workOrder);
        WorkOrder CreateProductWorkOrder(WorkOrder workOrder);
        WorkOrder CreateRoomWorkOrder(WorkOrder workOrder);
        WorkOrder CreateStoreWorkOrder(WorkOrder workOrder);
        WorkOrder CreateStructureWorkOrder(WorkOrder workOrder);
        WorkOrder UpdateWorkOrder(WorkOrder workOrder);
        WorkOrder DeleteWorkOrder(WorkOrder workOrder);
    }
}
