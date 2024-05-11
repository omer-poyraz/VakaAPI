using Entities.DTOs.ProductDto;
using Entities.RequestFeature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager _manager;
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllProductsAsync([FromQuery] ProductParameters parameters)
        {
            var pro = await _manager.ProductService.GetAllProductsAsync(parameters, false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pro.metaData));
            return Ok(pro.dtos);
        }

        [HttpGet("Get/{id:int}")]
        public async Task<IActionResult> GetProductAsync([FromRoute] int id)
        {
            var pro = await _manager.ProductService.GetProductAsync(id, false);
            return Ok(pro);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProductAsync([FromBody] ProductDtoForInsertion productDtoForInsertion)
        {
            var pro = await _manager.ProductService.CreateProductAsync(productDtoForInsertion);
            return Ok(pro);
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] int id, [FromBody] ProductDtoForUpdate productDtoForUpdate)
        {
            var pro = await _manager.ProductService.UpdateProductAsync(id, productDtoForUpdate, false);
            return Ok(pro);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            var pro = await _manager.ProductService.DeleteProductAsync(id, false);
            return Ok(pro);
        }
    }
}
