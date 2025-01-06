using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoOperationDto
{
    public record CargoOperationDtoForUpdate : CargoOperationDtoForManipulation
    {
        [Required]
        public int CargoOperationId { get; set; }
    }
}
