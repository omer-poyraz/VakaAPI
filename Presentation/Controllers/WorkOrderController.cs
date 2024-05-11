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
