using Entities.DTOs.UserDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] UserParameters userParameters)
        {
            var users = await _manager.UserService.GetAllUsersAsync(userParameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(users.metaData));
            return Ok(users.userDtos);
        }

        [HttpGet("Get/{userId:int}")]
        public async Task<IActionResult> GetUserAsync([FromRoute] int userId)
        {
            var user = await _manager.UserService.GetOneUserByIdAsync(userId, false);
            return Ok(user);
        }

        [HttpPut("Update/{userId:int}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] int userId, [FromBody] UserDtoForUpdate userDtoForUpdate)
        {
            var user = await _manager.UserService.UpdateOneUserAsync(userId, userDtoForUpdate, false);
            return Ok(user);
        }

        [HttpDelete("Delete/{userId:int}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int userId)
        {
            var user = await _manager.UserService.DeleteOneUserAsync(userId, false);
            return Ok(user);
        }

        [HttpPut("ChangePassword/{userId:int}")]
        public async Task<IActionResult> ChangePasswordAsync([FromRoute] int userId, [FromBody] UserDtoForChangePassword userDto)
        {
            var user = await _manager.UserService.ChangePasswordAsync(userId, userDto.CurrentPassword!, userDto.NewPassword!, false);
            return Ok(user);
        }
    }
}
