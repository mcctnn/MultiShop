using System.ComponentModel.DataAnnotations;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDto
{
    public record CargoDetailDtoForUpdate : CargoDetailDtoForManipulation
    {
        [Required]
        public int CargoDetailId { get; set; }
    }
}
