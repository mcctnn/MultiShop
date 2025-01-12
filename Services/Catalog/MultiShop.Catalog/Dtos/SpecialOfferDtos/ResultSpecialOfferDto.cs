namespace MultiShop.Catalog.Dtos.SpecialOfferDtos
{
    public record ResultSpecialOfferDto
    {
        public string SpecialOfferId { get; init; }
        public string Title { get; init; }
        public string SubTitle { get; init; }
        public string ImageUrl { get; init; }
    }
}
