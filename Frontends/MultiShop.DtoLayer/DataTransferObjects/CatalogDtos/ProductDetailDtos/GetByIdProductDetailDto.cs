namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.ProductDetailDtos
{
    public record GetByIdProductDetailDto
    {
        public string ProductDetailId { get; init; }
        public string ProductDetailDescription { get; init; }
        public string ProductDetailInfo { get; init; }
        public string ProductId { get; init; }
    }
}
