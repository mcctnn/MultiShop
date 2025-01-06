using MultiShop.Cargo.DtoLayer.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoOperationService
    {
        Task<IEnumerable<CargoOperation>> GetCargoCompaniesAsync(bool trackChanges);
        Task<CargoOperationDto> GetCargoOperationByIdAsync(int id, bool trackChanges);
        Task<CargoOperationDto> CreateOneOperationAsync(CargoOperationDtoForInsertion cargoOperationDtoForInsertion);
        Task UpdateOneOperationAsync(int id, CargoOperationDtoForUpdate cargoOperationDtoForUpdate, bool trackChanges);
        Task DeleteOneOperationAsync(int id, bool trackChanges);
    }
}
