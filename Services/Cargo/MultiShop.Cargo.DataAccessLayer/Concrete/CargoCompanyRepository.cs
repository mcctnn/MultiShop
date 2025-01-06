using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoCompanyRepository : RepositoryBase<CargoCompany>, ICargoCompanyRepository
    {
        public CargoCompanyRepository(CargoContext context) : base(context)
        {
        }

        public void CreateOneCargoCompany(CargoCompany cargoCompany)=> Create(cargoCompany);

        public void DeleteOneCargoCompany(CargoCompany cargoCompany) => Delete(cargoCompany);

        public async Task<List<CargoCompany>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b=>b.CargoCompanyId).ToListAsync();
        }

        public async Task<CargoCompany> GetByIdAsync(int id, bool trackChanges) => await FindByCondition(b => b.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCargoCompany(CargoCompany cargoCompany) => Update(cargoCompany);
    }
}
