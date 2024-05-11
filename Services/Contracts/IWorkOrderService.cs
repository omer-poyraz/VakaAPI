using Entities.DTOs.WorkOrderDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IWorkOrderService
    {
        Task<(IEnumerable<WorkOrderDto> dtos, MetaData metaData)> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges);
        Task<WorkOrderDto> GetWorkOrderAsync(int id, bool trackChanges);
        Task<WorkOrderDto> CreateWorkOrderAsync(WorkOrderDtoForInsertion workOrderDto);
        Task<WorkOrderDto> UpdateWorkOrderAsync(int id, WorkOrderDtoForUpdate workOrderDto, bool trackChanges);
        Task<WorkOrderDto> DeleteWorkOrderAsync(int id, bool trackChanges);
    }
}
