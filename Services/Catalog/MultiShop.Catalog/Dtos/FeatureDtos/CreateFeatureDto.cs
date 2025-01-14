namespace MultiShop.Catalog.Dtos.FeatureDtos
{
    public record CreateFeatureDto
    {
        public string FeatureName { get; init; }
        public string Icon { get; init; }
    }
}
