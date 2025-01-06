using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoCustomerDto
{
    public abstract record CargoCustomerDtoForManipulation
    {
        [Required(ErrorMessage ="The field is required..")]
        public string CargoCustomerName { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerSurname { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerDistrict { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerCity { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerEmail { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerPhone { get; init; }
        [Required(ErrorMessage = "The field is required..")]

        public string CargoCustomerAddress { get; init; }
    }
}
