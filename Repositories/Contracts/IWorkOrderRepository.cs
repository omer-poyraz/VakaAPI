using Entities.Models;
using Entities.RequestFeature;

namespace Repositories.Contracts
{
    public interface IWorkOrderRepository : IRepositoryBase<WorkOrder>
    {
        Task<PagedList<WorkOrder>> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges);
        Task<WorkOrder> GetWorkOrderAsync(int id, bool trackChanges);
        WorkOrder CreateWorkOrder(WorkOrder workOrder);
        WorkOrder UpdateWorkOrder(WorkOrder workOrder);
        WorkOrder DeleteWorkOrder(WorkOrder workOrder);
    }
}
