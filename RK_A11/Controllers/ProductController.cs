using Microsoft.AspNetCore.Mvc;
using RK_A11.DTO;
using RK_A11.Interface;

namespace RK_A11.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task AddProduct([FromBody] ProductDTO product)
        {
            await _service.AddProduct(product);
        }

        [HttpPut("{id}")]
        public async Task UpdateProduct(int id, [FromBody] ProductDTO product)
        {
            await _service.UpdateProduct(id, product);
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProduct(int id)
        {
            return await _service.GetProduct(id);
        }

        [HttpGet("all")]
        public async Task<List<ProductDTO>> GetAllProducts()
        {
            return await _service.GetAllProducts();
        }
    }
}