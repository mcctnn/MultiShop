namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.FeatureDtos
{
    public record CreateFeatureDto
    {
        public string FeatureName { get; init; }
        public string Icon { get; init; }
    }
}
