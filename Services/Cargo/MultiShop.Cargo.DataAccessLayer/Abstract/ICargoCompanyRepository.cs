using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCompanyRepository:IRepositoryBase<CargoCompany>
    {
        Task<List<CargoCompany>> GetAllAsync(bool trackChanges);
        Task<CargoCompany> GetByIdAsync(int id,bool trackChanges);
        void CreateOneCargoCompany(CargoCompany cargoCompany);
        void UpdateOneCargoCompany(CargoCompany cargoCompany);
        void DeleteOneCargoCompany(CargoCompany cargoCompany);
    }
}
