using AutoMapper;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CargoOperationManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<CargoOperationDto> CreateOneOperationAsync(CargoOperationDtoForInsertion cargoOperationDtoForInsertion)
        {
            var cargoOperation = _mapper.Map<CargoOperation>(cargoOperationDtoForInsertion);
            _manager.CargoOperationRepo.CreateOneCargoOperation(cargoOperation);
            await _manager.SaveAsync();
            return _mapper.Map<CargoOperationDto>(cargoOperation);
        }

        public async Task DeleteOneOperationAsync(int id, bool trackChanges)
        {
            var cargoOperation = await GetOneOperationByIdAndCheckExistence(id, trackChanges);
            _manager.CargoOperationRepo.DeleteOneCargoOperation(cargoOperation);
            await _manager.SaveAsync();
        }

        private async Task<CargoOperation> GetOneOperationByIdAndCheckExistence(int id, bool trackChanges)
        {
            var cargoOperation = await _manager.CargoOperationRepo.GetCargoOperationByIdAsync(id, trackChanges);

            if (cargoOperation is null)
            {
                throw new Exception($"Cargo operation with the id:{id} not found");
            }
            return cargoOperation;
        }

        public async Task<IEnumerable<CargoOperation>> GetCargoOperationsAsync(bool trackChanges)
        {
            var operations =await _manager.CargoOperationRepo.GetAllCargoOperationsAsync(trackChanges);
            return operations;
        }

        public async Task<CargoOperationDto> GetCargoOperationByIdAsync(int id, bool trackChanges)
        {
            var cargoOperation = await GetOneOperationByIdAndCheckExistence(id, trackChanges);
            
            return _mapper.Map<CargoOperationDto>(cargoOperation);
        }

        public async Task UpdateOneOperationAsync(int id, CargoOperationDtoForUpdate cargoOperationDtoForUpdate, bool trackChanges)
        {
            var cargoOperation = await GetOneOperationByIdAndCheckExistence(id, trackChanges);
            cargoOperation = _mapper.Map<CargoOperation>(cargoOperationDtoForUpdate);
            _manager.CargoOperationRepo.UpdateOneCargoOperation(cargoOperation);
            await _manager.SaveAsync();
        }
    }
}
