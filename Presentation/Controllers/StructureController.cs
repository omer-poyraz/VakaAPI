using Entities.DTOs.StructureDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/Structure")]
    public class StructureController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public StructureController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllStructuresAsync([FromQuery] StructureParameters parameters)
        {
            var str = await _manager.StructureService.GetAllStructuresAsync(parameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(str.metaData));
            return Ok(str.structureDtos);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetStructureAsync([FromRoute]int id)
        {
            var str = await _manager.StructureService.GetStructureAsync(id, false);
            return Ok(str);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateStructureAsync([FromBody] StructureDtoForInsertion structureDto)
        {
            var str = await _manager.StructureService.CreateStructureAsync(structureDto);
            return Ok(str);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateStructureAsync([FromRoute] int id, [FromBody] StructureDtoForUpdate structureDto)
        {
            var str = await _manager.StructureService.UpdateStructureAsync(id, structureDto, false);
            return Ok(str);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteStructureAsync([FromRoute] int id)
        {
            var str = await _manager.StructureService.DeleteStructureAsync(id, false);
            return Ok(str);
        }
    }
}
