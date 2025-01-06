using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoOperationDto
{
    public abstract record CargoOperationDtoForManipulation
    {
        [Required]
        public string Barcode { get; init; }
        [Required]
        public string Description { get; init; }
        [Required]
        public DateTime OperationDate { get; init; }
    }
}
