using MultiShop.Cargo.DtoLayer.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoDetailService
    {
        Task<IEnumerable<CargoDetail>> GetCargoCompaniesAsync(bool trackChanges);
        Task<CargoDetailDto> GetCargoDetailByIdAsync(int id, bool trackChanges);
        Task<CargoDetailDto> CreateOneDetailAsync(CargoDetailDtoForInsertion cargoDetailDtoForInsertion);
        Task UpdateOneDetailAsync(int id, CargoDetailDtoForUpdate cargoDetailDtoForUpdate, bool trackChanges);
        Task DeleteOneDetailAsync(int id, bool trackChanges);
    }
}
