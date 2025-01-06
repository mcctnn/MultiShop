using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoDetailRepository : RepositoryBase<CargoDetail>, ICargoDetailRepository
    {
        public CargoDetailRepository(CargoContext context) : base(context)
        {

        }

        public void CreateOneCargoDetail(CargoDetail cargoDetail) => Create(cargoDetail);

        public void DeleteOneCargoDetail(CargoDetail cargoDetail)=>Delete(cargoDetail);

        public async Task<List<CargoDetail>> GetAllAsync(bool trackChanges)
        {
           return await FindAll(trackChanges).OrderBy(b => b.CargoDetailId).ToListAsync();
        }

        public  async Task<CargoDetail> GetByIdAsync(int id, bool trackChanges) =>await FindByCondition(b => b.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCargoDetail(CargoDetail cargoDetail)=> Update(cargoDetail);
    }
}
