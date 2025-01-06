using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoDetailRepository:IRepositoryBase<CargoDetail>
    {
        Task<List<CargoDetail>> GetAllAsync(bool trackChanges);
        Task<CargoDetail> GetByIdAsync(int id, bool trackChanges);
        void CreateOneCargoDetail(CargoDetail cargoDetail);
        void UpdateOneCargoDetail(CargoDetail cargoDetail);
        void DeleteOneCargoDetail(CargoDetail cargoDetail);
    }
}
