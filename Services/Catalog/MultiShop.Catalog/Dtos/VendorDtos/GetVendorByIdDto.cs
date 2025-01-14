namespace MultiShop.Catalog.Dtos.VendorDtos
{
    public record GetVendorByIdDto
    {
        public string VendorId { get; init; }
        public string VendorName { get; init; }
        public string ImageUrl { get; init; }
    }
}
