using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoOperationRepository : IRepositoryBase<CargoOperation>
    {
        Task<List<CargoOperation>> GetAllAsync(bool trackChanges);
        Task<CargoOperation> GetByIdAsync(int id, bool trackChanges);
        void CreateOneCargoOperation(CargoOperation cargoOperation);
        void UpdateOneCargoOperation(CargoOperation cargoOperation);
        void DeleteOneCargoOperation(CargoOperation cargoOperation);
    }
}
