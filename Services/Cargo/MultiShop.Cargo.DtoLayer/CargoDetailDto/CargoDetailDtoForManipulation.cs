using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDto
{
    public abstract  record CargoDetailDtoForManipulation
    {
        [Required]
        public int SenderCustomer { get; init; }
        [Required]
        public string? ReceiverCustomer { get; init; }
        [Required]
        public int Barcode { get; init; }
    }
}
