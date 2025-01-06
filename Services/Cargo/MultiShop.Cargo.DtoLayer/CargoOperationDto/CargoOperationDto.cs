namespace MultiShop.Cargo.DtoLayer.CargoOperationDto
{
    public record CargoOperationDto
    {
        public int CargoOperationId { get; init; }
        public string Barcode { get; init; }
        public string Description { get; init; }
        public DateTime OperationDate { get; init; }
    }
}
