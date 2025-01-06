using AutoMapper;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoCustomerManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CargoCustomerDto> CreateOneCustomerAsync(CargoCustomerDtoForInsertion cargoCustomerDtoForInsertion)
        {
            var cargoCustomer = _mapper.Map<CargoCustomer>(cargoCustomerDtoForInsertion);

            _manager.CargoCustomerRepo.CreateOneCargoCustomer(cargoCustomer);
            await _manager.SaveAsync();

            return _mapper.Map<CargoCustomerDto>(cargoCustomer);
        }

        public async Task DeleteOneCustomerAsync(int id, bool trackChanges)
        {
            var cargoCustomer = await GetOneCustomerByIdAndCheckExistence(id, trackChanges);
            _manager.CargoCustomerRepo.DeleteOneCargoCustomer(cargoCustomer);
            await _manager.SaveAsync();
        }

        private async Task<CargoCustomer> GetOneCustomerByIdAndCheckExistence(int id, bool trackChanges)
        {
            var cargoCustomer = await _manager.CargoCustomerRepo.GetByIdAsync(id, trackChanges);
            if (cargoCustomer is null)
            {
                throw new Exception($"Cargo customer with the id:{id} not found");
            }
            return cargoCustomer;
        }

        public async Task<IEnumerable<CargoCustomer>> GetCargoCompaniesAsync(bool trackChanges)
        {
            var companies = await _manager.CargoCustomerRepo.GetAllAsync(trackChanges);
            return companies;
        }

        public async Task<CargoCustomerDto> GetCargoCustomerByIdAsync(int id, bool trackChanges)
        {
            var cargoCustomer = await GetOneCustomerByIdAndCheckExistence(id, trackChanges);
            
            return _mapper.Map<CargoCustomerDto>(cargoCustomer);
        }

        public async Task UpdateOneCustomerAsync(int id, CargoCustomerDtoForUpdate cargoCustomerDtoForUpdate, bool trackChanges)
        {
            var cargoCustomer = await GetOneCustomerByIdAndCheckExistence(id, trackChanges);

            cargoCustomer = _mapper.Map<CargoCustomer>(cargoCustomerDtoForUpdate);
            _manager.CargoCustomerRepo.UpdateOneCargoCustomer(cargoCustomer);

            await _manager.SaveAsync();
        }
    }
}
