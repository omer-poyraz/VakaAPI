using AutoMapper;
using Entities.DTOs.WorkOrderDto;
using Entities.Exceptions.WorkOrder;
using Entities.Models;
using Entities.RequestFeature;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class WorkOrderService : IWorkOrderService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public WorkOrderService(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<WorkOrderDto> CreateWorkOrderAsync(WorkOrderDtoForInsertion workOrderDto)
        {
            var work = _mapper.Map<WorkOrder>(workOrderDto);
            _manager.WorkOrderRepository.CreateWorkOrder(work);
            await _manager.SaveAsync();
            return _mapper.Map<WorkOrderDto>(work);
        }

        public async Task<WorkOrderDto> DeleteWorkOrderAsync(int id, bool trackChanges)
        {
            var work = await CheckExists(id, trackChanges);
            _manager.WorkOrderRepository.DeleteWorkOrder(work);
            await _manager.SaveAsync();
            return _mapper.Map<WorkOrderDto>(work);
        }

        public async Task<(IEnumerable<WorkOrderDto> dtos, MetaData metaData)> GetAllWorkOrdersAsync(WorkOrderParameters parameters, bool trackChanges)
        {
            var works = await _manager.WorkOrderRepository.GetAllWorkOrdersAsync(parameters, trackChanges);
            var workDto = _mapper.Map<IEnumerable<WorkOrderDto>>(works);
            return (workDto, works.MetaData);
        }

        public async Task<WorkOrderDto> GetWorkOrderAsync(int id, bool trackChanges)
        {
            var work = await CheckExists(id, trackChanges);
            return _mapper.Map<WorkOrderDto>(work);
        }

        public async Task<WorkOrderDto> UpdateWorkOrderAsync(int id, WorkOrderDtoForUpdate workOrderDto, bool trackChanges)
        {
            var work = await CheckExists(id, trackChanges);
            work = _mapper.Map<WorkOrder>(workOrderDto);
            _manager.WorkOrderRepository.UpdateWorkOrder(work);
            await _manager.SaveAsync();
            return _mapper.Map<WorkOrderDto>(work);
        }

        private async Task<WorkOrder> CheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.WorkOrderRepository.GetWorkOrderAsync(id, trackChanges);
            if (entity is null)
            {
                _logger.LogError($"{id} number Id not found exception!");
                throw new WorkOrderNotFoundException(id);
            }
            return entity;
        }
    }
}
