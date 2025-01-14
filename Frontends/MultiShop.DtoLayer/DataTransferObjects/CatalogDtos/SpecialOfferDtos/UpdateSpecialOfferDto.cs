namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.SpecialOfferDtos
{
    public record UpdateSpecialOfferDto
    {
        public string SpecialOfferId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
