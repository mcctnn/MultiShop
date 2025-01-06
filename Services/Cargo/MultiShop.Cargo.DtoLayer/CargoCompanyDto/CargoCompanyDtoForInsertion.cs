using System.ComponentModel.DataAnnotations;


namespace MultiShop.Cargo.DtoLayer.CargoCompanyDto
{
    public record CargoCompanyDtoForInsertion:CargoCompanyDtoForManipulation
    {
        [Required(ErrorMessage = "Id is a required field.")]
        public int CargoCompanyId { get; init; }
    }
}
