using Entities.Models;
using Entities.RequestFeature;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;

namespace Repositories.EFCore
{
    public class WorkOrderRepository : RepositoryBase<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(RepositoryContext context) : base(context)
        {
        }

        public WorkOrder CreateWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
            return workOrder;
        }

        public WorkOrder DeleteWorkOrder(WorkOrder workOrder)
        {
            Delete(workOrder);
            return workOrder;
        }

        public async Task<PagedList<WorkOrder>> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges)
        {
            var workOrders = await FindAll(trackChanges)
                .OrderBy(w => w.WorkOrderId)
                .Include(w => w.Product)
                .Include(w => w.Room)
                .Include(w => w.Store)
                .Include(w => w.Structure)
                .SearchWorkOrder(parameters.SearchTerm!)
                .ToListAsync();

            return PagedList<WorkOrder>.ToPagedList(workOrders, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<WorkOrder> GetWorkOrderAsync(int id, bool trackChanges) =>
            await FindByCondition(w => w.WorkOrderId.Equals(id), trackChanges)
            .Include(w => w.Product)
            .Include(w => w.Room)
            .Include(w => w.Store)
            .Include(w => w.Structure)
            .SingleOrDefaultAsync();

        public WorkOrder UpdateWorkOrder(WorkOrder workOrder)
        {
            Update(workOrder);
            return workOrder;
        }
    }
}
