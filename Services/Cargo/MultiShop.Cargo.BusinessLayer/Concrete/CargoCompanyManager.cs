using AutoMapper;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoCompanyManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CargoCompanyDto> CreateOneCompanyAsync(CargoCompanyDtoForInsertion cargoCompanyDtoForInsertion)
        {
            var cargoCompany = _mapper.Map<CargoCompany>(cargoCompanyDtoForInsertion);

            _manager.CargoCompanyRepo.CreateOneCargoCompany(cargoCompany);
            await _manager.SaveAsync();

            return _mapper.Map<CargoCompanyDto>(cargoCompany);
        }

        public async Task DeleteOneCompanyAsync(int id, bool trackChanges)
        {
            var cargoCompany = await GetOneCompanyByIdAndCheckExistence(id, trackChanges);
            _manager.CargoCompanyRepo.DeleteOneCargoCompany(cargoCompany);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<CargoCompany>> GetCargoCompaniesAsync(bool trackChanges)
        {
            var companies = await _manager.CargoCompanyRepo.GetAllCargoCompaniesAsync(trackChanges);
            return companies;
        }

        public async Task<CargoCompanyDto> GetCargoCompanyByIdAsync(int id, bool trackChanges)
        {
            var cargoCompany = await GetOneCompanyByIdAndCheckExistence(id, trackChanges);
            if (cargoCompany is null)
            {
                throw new Exception($"Cargo company with the id:{id} not found");
            }
            return _mapper.Map<CargoCompanyDto>(cargoCompany);
        }

        public async Task UpdateOneCompanyAsync(int id, CargoCompanyDtoForUpdate cargoCompanyDtoForUpdate, bool trackChanges)
        {
            var cargoCompany = await GetOneCompanyByIdAndCheckExistence(id, trackChanges);
            cargoCompany = _mapper.Map<CargoCompany>(cargoCompanyDtoForUpdate);
            _manager.CargoCompanyRepo.UpdateOneCargoCompany(cargoCompany);
            await _manager.SaveAsync();
        }

        private async Task<CargoCompany> GetOneCompanyByIdAndCheckExistence(int id, bool trackChanges)
        {
            var cargoCompany = await _manager.CargoCompanyRepo.GetCargoCompanyByIdAsync(id, trackChanges);
            if (cargoCompany is null)
            {
                throw new Exception("Cargo company not found");
            }
            return cargoCompany;
        }
    }
}
