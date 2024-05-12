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

        public WorkOrder CreateProductWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
            return workOrder;
        }

        public WorkOrder CreateRoomWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
            return workOrder;
        }

        public WorkOrder CreateStoreWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
            return workOrder;
        }

        public WorkOrder CreateStructureWorkOrder(WorkOrder workOrder)
        {
            Create(workOrder);
            return workOrder;
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

        public async Task<IEnumerable<WorkOrder>> GetProductWorkOrderAsync(int productId, bool trackChanges)
        {
            var workOrders = await FindAll(trackChanges)
                .OrderBy(w => w.WorkOrderId)
                .Include(w => w.Product)
                .Include(w => w.Room)
                .Include(w => w.Store)
                .Include(w => w.Structure)
                .Where(w => w.ProductId.Equals(productId))
                .ToListAsync();
            return workOrders;
        }

        public async Task<IEnumerable<WorkOrder>> GetRoomWorkOrderAsync(int roomId, bool trackChanges)
        {
            var workOrders = await FindAll(trackChanges)
                .OrderBy(w => w.WorkOrderId)
                .Include(w => w.Product)
                .Include(w => w.Room)
                .Include(w => w.Store)
                .Include(w => w.Structure)
                .Where(w => w.RoomId.Equals(roomId))
                .ToListAsync();
            return workOrders;
        }

        public async Task<IEnumerable<WorkOrder>> GetStoreWorkOrderAsync(int storeId, bool trackChanges)
        {
            var workOrders = await FindAll(trackChanges)
                .OrderBy(w => w.WorkOrderId)
                .Include(w => w.Product)
                .Include(w => w.Room)
                .Include(w => w.Store)
                .Include(w => w.Structure)
                .Where(w => w.StoreId.Equals(storeId))
                .ToListAsync();
            return workOrders;
        }

        public async Task<IEnumerable<WorkOrder>> GetStructureWorkOrderAsync(int structureId, bool trackChanges)
        {
            var workOrders = await FindAll(trackChanges)
                .OrderBy(w => w.WorkOrderId)
                .Include(w => w.Product)
                .Include(w => w.Room)
                .Include(w => w.Store)
                .Include(w => w.Structure)
                .Where(w => w.StructureId.Equals(structureId))
                .ToListAsync();
            return workOrders;
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
