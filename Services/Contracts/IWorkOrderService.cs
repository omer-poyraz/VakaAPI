using Entities.DTOs.WorkOrderDto;
using Entities.RequestFeature;

namespace Services.Contracts
{
    public interface IWorkOrderService
    {
        Task<(IEnumerable<WorkOrderDto> dtos, MetaData metaData)> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges);
        Task<IEnumerable<WorkOrderDto>> GetProductWorkOrderAsync(int productId, bool trackChanges);
        Task<IEnumerable<WorkOrderDto>> GetRoomWorkOrderAsync(int roomId, bool trackChanges);
        Task<IEnumerable<WorkOrderDto>> GetStoreWorkOrderAsync(int storeId, bool trackChanges);
        Task<IEnumerable<WorkOrderDto>> GetStructureWorkOrderAsync(int structureId, bool trackChanges);
        Task<WorkOrderDto> GetWorkOrderAsync(int id, bool trackChanges);
        Task<WorkOrderDto> CreateWorkOrderAsync(WorkOrderDtoForInsertion workOrderDto);
        Task<WorkOrderDto> CreateProductWorkOrderAsync(WorkOrderDtoForProductInsertion productWorkOrderDto);
        Task<WorkOrderDto> CreateRoomWorkOrderAsync(WorkOrderDtoForRoomInsertion roomWorkOrderDto);
        Task<WorkOrderDto> CreateStoreWorkOrderAsync(WorkOrderDtoForStoreInsertion workOrderDto);
        Task<WorkOrderDto> CreateStructureWorkOrderAsync(WorkOrderDtoForStructureInsertion workOrderDto);
        Task<WorkOrderDto> UpdateWorkOrderAsync(int id, WorkOrderDtoForUpdate workOrderDto, bool trackChanges);
        Task<WorkOrderDto> DeleteWorkOrderAsync(int id, bool trackChanges);
    }
}
