using MultiShop.Cargo.DtoLayer.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCompanyService
    {
        Task<IEnumerable<CargoCompany>> GetCargoCompaniesAsync(bool trackChanges);
        Task<CargoCompanyDto> GetCargoCompanyByIdAsync(int id, bool trackChanges);
        Task<CargoCompanyDto> CreateOneCompanyAsync(CargoCompanyDtoForInsertion cargoCompanyDtoForInsertion);
        Task UpdateOneCompanyAsync(int id ,CargoCompanyDtoForUpdate cargoCompanyDtoForUpdate,bool trackChanges);
        Task DeleteOneCompanyAsync(int id,bool trackChanges);
    }
}
