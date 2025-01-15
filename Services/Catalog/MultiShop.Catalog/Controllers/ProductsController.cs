using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    //[Authorize]
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
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProduct(string id)
        {
            var result = await _productService.GetByIdProductAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string ProductId)
        {
            await _productService.DeleteProductAsync(ProductId);
            return Ok("Ürün silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün güncellendi");
        }

        [HttpGet("GetAllProductsWithCategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var result= await _productService.GetProductsWithCategoryAsync();
            return Ok(result);
        }

        [HttpGet("GetProductWithCategoryByCategoryId")]
        public async Task<IActionResult> GetProductWithCategoryByCategoryId(string categoryId)
        {
            var result=await _productService.GetProductsWithCategoryByCategoryIdAsync(categoryId);
            return Ok(result);
        }
    }
}
