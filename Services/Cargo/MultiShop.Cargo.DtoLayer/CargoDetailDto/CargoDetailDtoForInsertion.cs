using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDto
{
    public record CargoDetailDtoForInsertion : CargoDetailDtoForManipulation
    {
        [Required]
        public int CargoDetailId { get; init; }
    }
}
