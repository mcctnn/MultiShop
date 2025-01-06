using AutoMapper;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoDetailManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CargoDetailDto> CreateOneDetailAsync(CargoDetailDtoForInsertion cargoDetailDtoForInsertion)
        {
            var cargoDetail = _mapper.Map<CargoDetail>(cargoDetailDtoForInsertion);

            _manager.CargoDetailRepo.CreateOneCargoDetail(cargoDetail);
            await _manager.SaveAsync();

            return _mapper.Map<CargoDetailDto>(cargoDetail);
        }

        public async Task DeleteOneDetailAsync(int id, bool trackChanges)
        {
            var cargoDetail = await GetOneDetailByIdAndCheckExistence(id, trackChanges);
        }

        private async Task<CargoDetail> GetOneDetailByIdAndCheckExistence(int id, bool trackChanges)
        {
            var cargoDetail = await _manager.CargoDetailRepo.GetByIdAsync(id, trackChanges);

            if (cargoDetail is null)
            {
                throw new Exception($"Cargo detail with the id :{id} is not found");
            }
            return cargoDetail;
        }

        public async Task<IEnumerable<CargoDetail>> GetCargoCompaniesAsync(bool trackChanges)
        {
            var companies = await _manager.CargoDetailRepo.GetAllAsync(trackChanges);

            return companies;
        }

        public async Task<CargoDetailDto> GetCargoDetailByIdAsync(int id, bool trackChanges)
        {
            var cargoDetail = await GetOneDetailByIdAndCheckExistence(id, trackChanges);

            return _mapper.Map<CargoDetailDto>(cargoDetail);

        }

        public async Task UpdateOneDetailAsync(int id, CargoDetailDtoForUpdate cargoDetailDtoForUpdate, bool trackChanges)
        {
            var cargoDetail = await GetOneDetailByIdAndCheckExistence(id, trackChanges);

            _mapper.Map<CargoDetail>(cargoDetailDtoForUpdate);
            _manager.CargoDetailRepo.UpdateOneCargoDetail(cargoDetail);
            await _manager.SaveAsync();
        }
    }
}
