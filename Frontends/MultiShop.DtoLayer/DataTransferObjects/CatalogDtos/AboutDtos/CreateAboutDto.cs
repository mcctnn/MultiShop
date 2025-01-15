namespace MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.AboutDtos
{
    public record CreateAboutDto
    {
        public string Description { get; init; }
        public string Address { get; init; }
        public string Email { get; init; }
        public string Phone { get; init; }
    }
}
