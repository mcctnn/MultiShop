using MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.CategoryDtos;

namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.ProductDtos
{
    public record ResultProductWithDetailDto
    {
        public string ProductId { get; init; }
        public string ProductName { get; init; }
        public decimal ProductPrice { get; init; }
        public string ProductImageUrl { get; init; }
        public string ProductDescription { get; init; }
        public string CategoryId { get; init; }
        public ResultCategoryDto Category { get; init; }
    }
}
