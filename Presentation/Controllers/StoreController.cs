using Entities.DTOs.StoreDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/Store")]
    public class StoreController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public StoreController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStoresAsync([FromQuery] StoreParameters storeParameters)
        {
            var store = await _manager.StoreService.GetAllStoresAsync(storeParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(store.metaData));
            return Ok(store.storeDtos);
        }

        [HttpGet("Structure/{id:int}")]
        public async Task<IActionResult> GetAllStoresByStructureAsync([FromRoute] int id)
        {
            var store = await _manager.StoreService.GetAllStoresByStructureAsync(id, false);
            return Ok(store);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetStoreAsync([FromRoute] int id)
        {
            var store = await _manager.StoreService.GetStoreAsync(id, false);
            return Ok(store);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateStoreAsync([FromBody] StoreDtoForInsertion storeDtoForInsertion)
        {
            var store = await _manager.StoreService.CreateStoreAsync(storeDtoForInsertion);
            return Ok(store);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateStoreAsync([FromRoute] int id, [FromBody] StoreDtoForUpdate storeDto)
        {
            var store = await _manager.StoreService.UpdateStoreAsync(id, storeDto, false);
            return Ok(store);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteStoreAsync([FromRoute] int id)
        {
            var store = await _manager.StoreService.DeleteStoreAsync(id, false);
            return Ok(store);
        }
    }
}
