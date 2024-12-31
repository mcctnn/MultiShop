using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result = await _productDetailService.GetAllProductDetailsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProductDetailAsync(string id)
        {
            var result = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetailAsync(string ProductDetailId)
        {
            await _productDetailService.DeleteProductDetailAsync(ProductDetailId);
            return Ok("Ürün detayı silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı güncellendi");
        }
    }
}
