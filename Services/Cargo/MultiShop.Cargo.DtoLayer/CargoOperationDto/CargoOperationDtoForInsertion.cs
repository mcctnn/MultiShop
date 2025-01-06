using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoOperationDto
{
    public record CargoOperationDtoForInsertion : CargoOperationDtoForManipulation
    {
        [Required]
        public int CargoOperationId { get; init; }
    }
}
