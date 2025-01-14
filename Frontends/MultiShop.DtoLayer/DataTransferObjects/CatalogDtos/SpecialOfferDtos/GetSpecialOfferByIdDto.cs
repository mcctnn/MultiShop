namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.SpecialOfferDtos
{
    public record GetSpecialOfferByIdDto
    {
        public string SpecialOfferId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
