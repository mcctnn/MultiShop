using MultiShop.Cargo.DtoLayer.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface ICargoCustomerService
    {
        Task<IEnumerable<CargoCustomer>> GetCargoCustomersAsync(bool trackChanges);
        Task<CargoCustomerDto> GetCargoCustomerByIdAsync(int id, bool trackChanges);
        Task<CargoCustomerDto> CreateOneCustomerAsync(CargoCustomerDtoForInsertion cargoCustomerDtoForInsertion);
        Task UpdateOneCustomerAsync(int id, CargoCustomerDtoForUpdate cargoCustomerDtoForUpdate, bool trackChanges);
        Task DeleteOneCustomerAsync(int id, bool trackChanges);
    }
}
