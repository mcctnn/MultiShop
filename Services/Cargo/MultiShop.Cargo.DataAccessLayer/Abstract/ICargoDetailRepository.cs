using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoDetailRepository:IRepositoryBase<CargoDetail>
    {
        Task<List<CargoDetail>> GetAllCargoDetailsAsync(bool trackChanges);
        Task<CargoDetail> GetCargoDetailByIdAsync(int id, bool trackChanges);
        void CreateOneCargoDetail(CargoDetail cargoDetail);
        void UpdateOneCargoDetail(CargoDetail cargoDetail);
        void DeleteOneCargoDetail(CargoDetail cargoDetail);
    }
}
