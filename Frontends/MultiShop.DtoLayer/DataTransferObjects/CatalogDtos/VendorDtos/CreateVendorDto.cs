namespace  MultiShop.DtoLayer.DataTransferObjects.CatalogDtos.VendorDtos
{
    public record CreateVendorDto
    {
        public string VendorName { get; init; }
        public string ImageUrl { get; init; }
    }
}
