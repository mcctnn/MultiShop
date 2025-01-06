using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoCompanyDto
{
    public  abstract record CargoCompanyDtoForManipulation
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [MinLength(2, ErrorMessage = "Title must consist of at least 2 characters")]
        [MaxLength(50, ErrorMessage = "Title must consist of at maximum 50 characters")]
        public string CargoCompanyName { get; init; }
    }
}
