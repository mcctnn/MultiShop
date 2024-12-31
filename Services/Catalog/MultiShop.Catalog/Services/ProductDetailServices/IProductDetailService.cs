using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDto);
        Task DeleteProductDetailAsync(string productId);
        Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    }
}
