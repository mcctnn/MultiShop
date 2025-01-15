namespace MultiShop.Catalog.Dtos.SocialMediaDtos
{
    public record CreateSocialMediaDto
    {
        public string SocialMediaName { get; init; }
        public string Link { get; init; }
        public string Icon { get; init; }
    }
}
