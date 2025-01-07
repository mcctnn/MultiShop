using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerRepository:IRepositoryBase<CargoCustomer>
    {
        Task<List<CargoCustomer>> GetAllCargoCustomersAsync(bool trackChanges);
        Task<CargoCustomer> GetCargoCustomerByIdAsync(int id, bool trackChanges);
        void CreateOneCargoCustomer(CargoCustomer cargoCustomer);
        void UpdateOneCargoCustomer(CargoCustomer cargoCustomer);
        void DeleteOneCargoCustomer(CargoCustomer cargoCustomer);
    }
}
