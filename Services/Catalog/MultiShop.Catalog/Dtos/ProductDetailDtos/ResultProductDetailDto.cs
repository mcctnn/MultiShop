namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public record ResultProductDetailDto
    {
        public string ProductDetailId { get; init; }
        public string ProductDetailDescription { get; init; }
        public string ProductDetailInfo { get; init; }
        public string ProductId { get; init; }
    }
}
