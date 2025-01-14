namespace MultiShop.Catalog.Dtos.FeatureDtos
{
    public record ResultFeatureDto
    {
        public string FeatureId { get; init; }
        public string FeatureName { get; init; }
        public string Icon { get; init; }
    }
}
