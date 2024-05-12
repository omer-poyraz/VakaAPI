using Entities.DTOs.WorkOrderDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/WorkOrder")]
    public class WorkOrderController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public WorkOrderController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllWorkOrdersAsync([FromQuery] WorkOrderParameters parameters)
        {
            var work = await _manager.WorkOrderService.GetAllWorkOrdersAsync(parameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(work.metaData));
            return Ok(work.dtos);
        }

        [HttpGet("ProductGet/{productId:int}")]
        public async Task<IActionResult> GetProductWorkOrderAsync([FromRoute] int productId)
        {
            var product = await _manager.WorkOrderService.GetProductWorkOrderAsync(productId, false);
            return Ok(product);
        }

        [HttpGet("RoomGet/{roomId:int}")]
        public async Task<IActionResult> GetRoomWorkOrderAsync([FromRoute] int roomId)
        {
            var rooms = await _manager.WorkOrderService.GetRoomWorkOrderAsync(roomId, false);
            return Ok(rooms);
        }

        [HttpGet("StoreGet/{storeId:int}")]
        public async Task<IActionResult> GetStoreWorkOrderAsync([FromRoute] int storeId)
        {
            var stores = await _manager.WorkOrderService.GetStoreWorkOrderAsync(storeId, false);
            return Ok(stores);
        }

        [HttpGet("StructureGet/{structureId:int}")]
        public async Task<IActionResult> GetStructureWorkOrderAsync([FromRoute] int structureId)
        {
            var structures = await _manager.WorkOrderService.GetStructureWorkOrderAsync(structureId, false);
            return Ok(structures);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetWorkOrderAsync([FromRoute] int id)
        {
            var work = await _manager.WorkOrderService.GetWorkOrderAsync(id, false);
            return Ok(work);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateWorkOrderAsync([FromBody] WorkOrderDtoForInsertion workOrder)
        {
            var work = await _manager.WorkOrderService.CreateWorkOrderAsync(workOrder);
            return Ok(work);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductWorkOrderAsync([FromBody] WorkOrderDtoForProductInsertion workOrderDtoForProductInsertion)
        {
            var product = await _manager.WorkOrderService.CreateProductWorkOrderAsync(workOrderDtoForProductInsertion);
            return Ok(product);
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoomWorkOrderAsync([FromBody] WorkOrderDtoForRoomInsertion workOrderDtoForRoomInsertion)
        {
            var room = await _manager.WorkOrderService.CreateRoomWorkOrderAsync(workOrderDtoForRoomInsertion);
            return Ok(room);
        }

        [HttpPost("CreateStore")]
        public async Task<IActionResult> CreateStoreWorkOrderAsync([FromBody] WorkOrderDtoForStoreInsertion workOrderDtoForStoreInsertion)
        {
            var store = await _manager.WorkOrderService.CreateStoreWorkOrderAsync(workOrderDtoForStoreInsertion);
            return Ok(store);
        }

        [HttpPost("CreateStructure")]
        public async Task<IActionResult> CreateStructureWorkOrderAsync([FromBody] WorkOrderDtoForStructureInsertion structureInsertion)
        {
            var structure = await _manager.WorkOrderService.CreateStructureWorkOrderAsync(structureInsertion);
            return Ok(structure);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateWorkOrderAsync([FromRoute] int id, [FromBody] WorkOrderDtoForUpdate workOrder)
        {
            var work = await _manager.WorkOrderService.UpdateWorkOrderAsync(id, workOrder, false);
            return Ok(work);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteWorkOrderAsync([FromRoute] int id)
        {
            var work = await _manager.WorkOrderService.DeleteWorkOrderAsync(id, false);
            return Ok(work);
        }
    }
}
