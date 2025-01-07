using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoOperationRepository : IRepositoryBase<CargoOperation>
    {
        Task<List<CargoOperation>> GetAllCargoOperationsAsync(bool trackChanges);
        Task<CargoOperation> GetCargoOperationByIdAsync(int id, bool trackChanges);
        void CreateOneCargoOperation(CargoOperation cargoOperation);
        void UpdateOneCargoOperation(CargoOperation cargoOperation);
        void DeleteOneCargoOperation(CargoOperation cargoOperation);
    }
}
