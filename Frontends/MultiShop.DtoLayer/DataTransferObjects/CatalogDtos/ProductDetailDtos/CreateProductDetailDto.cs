namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.ProductDetailDtos
{
    public record CreateProductDetailDto
    {
        public string ProductDetailDescription { get;   init; }
        public string ProductDetailInfo { get; init; }
        public string ProductId { get; init; }
    }
}
