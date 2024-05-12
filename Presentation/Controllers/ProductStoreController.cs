using Entities.DTOs.ProductStoreDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/ProductStore")]
    public class ProductStoreController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ProductStoreController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductStoreAsync()
        {
            var product = await _manager.ProductStoreService.GetAllProductStoreAsync(false);
            return Ok(product);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetProductStoreAsync([FromRoute] int id)
        {
            var product = await _manager.ProductStoreService.GetProductStoreAsync(id, false);
            return Ok(product);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductStoreAsync([FromBody] ProductStoreDtoForInsertion productStoreDtoForInsertion)
        {
            var product = await _manager.ProductStoreService.CreateProductStoreAsync(productStoreDtoForInsertion);
            return Ok(product);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProductStoreAsync([FromRoute]int id)
        {
            var product = await _manager.ProductStoreService.DeleteProductStoreAsync(id, false);
            return Ok(product);
        }
    }
}
