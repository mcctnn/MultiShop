using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductDto);
        Task DeleteProductImageAsync(string productId);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
