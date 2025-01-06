using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class CargoOperationRepository : RepositoryBase<CargoOperation>, ICargoOperationRepository
    {
        public CargoOperationRepository(CargoContext context) : base(context)
        {
        }

        public void CreateOneCargoOperation(CargoOperation cargoOperation)=>Create(cargoOperation);

        public void DeleteOneCargoOperation(CargoOperation cargoOperation)=> Delete(cargoOperation);

        public async Task<List<CargoOperation>> GetAllAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b => b.CargoOperationId).ToListAsync();
        }

        public async  Task<CargoOperation> GetByIdAsync(int id, bool trackChanges) => await FindByCondition(b => b.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void UpdateOneCargoOperation(CargoOperation cargoOperation) => Update(cargoOperation);
    }
}
