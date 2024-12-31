using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _productImageService.GetAllProductImagesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductImageAsync(string id)
        {
            var result = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImageAsync(string ProductImageId)
        {
            await _productImageService.DeleteProductImageAsync(ProductImageId);
            return Ok("Ürün resmi silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resmi güncellendi");
        }
    }
}
