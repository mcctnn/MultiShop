namespace MultiShop.Catalog.Dtos.VendorDtos
{
    public record ResultVendorDto
    {
        public string VendorId { get; init; }
        public string VendorName { get; init; }
        public string ImageUrl { get;init; }
    }
}
