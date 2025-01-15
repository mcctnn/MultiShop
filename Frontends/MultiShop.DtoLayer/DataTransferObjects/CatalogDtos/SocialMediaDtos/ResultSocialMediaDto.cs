namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.SocialMediaDtos
{
    public record ResultSocialMediaDto
    {
        public string SocialMediaId { get; init; }
        public string SocialMediaName { get; init; }
        public string Link { get; init; }
        public string Icon { get; init; }
    }
}
