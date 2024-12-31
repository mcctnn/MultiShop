using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductAsync(string id)
        {
            var result = await _productService.GetByIdProductAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(string ProductId)
        {
            await _productService.DeleteProductAsync(ProductId);
            return Ok("Ürün silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün güncellendi");
        }
    }
}
