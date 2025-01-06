namespace MultiShop.Cargo.DtoLayer.CargoDetailDto
{
    public record CargoDetailDto
    {
        public int CargoDetailId { get; init; }
        public int SenderCustomer { get; init; }
        public string? ReceiverCustomer { get; init; }
        public int Barcode { get; init; }
    }
}
