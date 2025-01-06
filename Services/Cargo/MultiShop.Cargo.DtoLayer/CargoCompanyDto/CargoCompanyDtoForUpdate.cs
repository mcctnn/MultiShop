using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoCompanyDto
{
    public record CargoCompanyDtoForUpdate : CargoCompanyDtoForManipulation
    {
        [Required(ErrorMessage = "Id is a required field.")]
        public int CargoCompanyId { get; set; }
    }
}
