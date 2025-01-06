namespace MultiShop.Cargo.DtoLayer.CargoCustomerDto
{
    public record CargoCustomerDto
    {
        public int CargoCustomerId { get; init; }
        public string CargoCustomerName { get; init; }
        public string CargoCustomerSurname { get; init; }
        public string CargoCustomerDistrict { get; init; }
        public string CargoCustomerCity { get; init; }
        public string CargoCustomerEmail { get; init; }
        public string CargoCustomerPhone { get; init; }
        public string CargoCustomerAddress { get; init; }
    }
}
