using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoCustomerRepository : RepositoryBase<CargoCustomer>, ICargoCustomerRepository
    {
        public CargoCustomerRepository(CargoContext context) : base(context)
        {
        }

        public void CreateOneCargoCustomer(CargoCustomer cargoCustomer) => Create(cargoCustomer);

        public void DeleteOneCargoCustomer(CargoCustomer cargoCustomer) => Delete(cargoCustomer);

        public async Task<List<CargoCustomer>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b => b.CargoCustomerId).ToListAsync();
        }

        public async Task<CargoCustomer> GetByIdAsync(int id, bool trackChanges)=> await FindByCondition(b => b.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCargoCustomer(CargoCustomer cargoCustomer) => Update(cargoCustomer);
    }
}
