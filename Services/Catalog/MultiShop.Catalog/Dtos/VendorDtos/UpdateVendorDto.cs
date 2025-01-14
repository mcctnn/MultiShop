namespace MultiShop.Catalog.Dtos.VendorDtos
{
    public record UpdateVendorDto
    {
        public string VendorId { get; init; }
        public string VendorName { get; init; }
        public string ImageUrl { get; init; }
    }
}
