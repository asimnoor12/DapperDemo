using DapperDemo.Models;
using DapperDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _productService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(Product product) => Ok(await _productService.AddAsync(product));

        [HttpPut]
        public async Task<IActionResult> Update(Product product) => Ok(await _productService.UpdateAsync(product));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _productService.DeleteAsync(id));

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category) => Ok(await _productService.GetProductsByCategoryAsync(category));
    }
}

