using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoCustomerDto
{
    public record CargoCustomerDtoForInsertion : CargoCustomerDtoForManipulation
    {
        [Required(ErrorMessage = "The field is required..")]
        public int CargoCustomerId { get; init; }
    }
}
