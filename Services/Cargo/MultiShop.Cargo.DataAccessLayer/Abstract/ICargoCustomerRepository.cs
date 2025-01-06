using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerRepository:IRepositoryBase<CargoCustomer>
    {
        Task<List<CargoCustomer>> GetAllAsync(bool trackChanges);
        Task<CargoCustomer> GetByIdAsync(int id, bool trackChanges);
        void CreateOneCargoCustomer(CargoCustomer cargoCustomer);
        void UpdateOneCargoCustomer(CargoCustomer cargoCustomer);
        void DeleteOneCargoCustomer(CargoCustomer cargoCustomer);
    }
}
