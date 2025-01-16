namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.ProductDetailDtos
{
    public record UpdateProductDetailDto
    {
        public string ProductDetailId { get; init; }
        public string ProductDetailDescription { get; init; }
        public string ProductDetailInfo { get; init; }
        public string ProductId { get; init; }
    }
}
