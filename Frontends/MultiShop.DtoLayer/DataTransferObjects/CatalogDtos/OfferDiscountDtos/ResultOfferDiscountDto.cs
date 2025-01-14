namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.OfferDiscountDtos
{
    public record ResultOfferDiscountDto
    {
        public string OfferDiscountId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
