namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.SpecialOfferDtos
{
    public record CreateSpecialOfferDto
    {
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
