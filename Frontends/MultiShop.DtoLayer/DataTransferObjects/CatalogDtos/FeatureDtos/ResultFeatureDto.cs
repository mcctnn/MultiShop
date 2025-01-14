namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.FeatureDtos
{
    public record ResultFeatureDto
    {
        public string FeatureId { get; init; }
        public string FeatureName { get; init; }
        public string Icon { get; init; }
    }
}
