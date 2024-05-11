using Entities.DTOs.RoomDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/Room")]
    public class RoomController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public RoomController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRoomsAsync([FromQuery] RoomParameters parameters)
        {
            var rooms = await _manager.RoomService.GetAllProductsAsync(parameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(rooms.metaData));
            return Ok(rooms.roomDto);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetRoomAsync([FromRoute] int id)
        {
            var room = await _manager.RoomService.GetRoomAsync(id, false);
            return Ok(room);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRoomAsync([FromBody] RoomDtoForInsertion roomDto)
        {
            var room = await _manager.RoomService.CreateRoomAsync(roomDto);
            return Ok(room);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateRoomAsync([FromRoute] int id, [FromBody] RoomDtoForUpdate roomDto)
        {
            var room = await _manager.RoomService.UpdateRoomAsync(id, roomDto, false);
            return Ok(room);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteRoomAsync([FromRoute] int id)
        {
            var room = await _manager.RoomService.DeleteRoomAsync(id, false);
            return Ok(room);
        }
    }
}
