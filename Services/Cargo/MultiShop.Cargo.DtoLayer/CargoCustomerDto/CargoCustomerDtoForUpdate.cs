using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoCustomerDto
{
    public record CargoCustomerDtoForUpdate : CargoCustomerDtoForManipulation
    {
        [Required(ErrorMessage = "The field is required..")]
        public int CargoCustomerId { get; set; }
    }
}
