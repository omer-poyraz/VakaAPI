using Entities.DTOs.ProductRoomDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/ProductRoom")]
    public class ProductRoomController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ProductRoomController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductRoomAsync()
        {
            var product = await _manager.ProductRoomService.GetAllProductRoomAsync(false);
            return Ok(product);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetProductRoomAsync([FromRoute] int id)
        {
            var product = await _manager.ProductRoomService.GetProductRoomAsync(id, false);
            return Ok(product);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductRoomAsync([FromBody] ProductRoomDtoForInsertion productRoomDto)
        {
            var product = await _manager.ProductRoomService.CreateProductRoomAsync(productRoomDto);
            return Ok(product);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProductRoomAsync([FromRoute] int id)
        {
            var product = await _manager.ProductRoomService.DeleteProductRoomAsync(id, false);
            return Ok(product);
        }
    }
}
