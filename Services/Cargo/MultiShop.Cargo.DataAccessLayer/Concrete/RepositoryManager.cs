using MultiShop.Cargo.DataAccessLayer.Abstract;

namespace MultiShop.Cargo.DataAccessLayer.Concrete
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly CargoContext _context;
        private ICargoCompanyRepository _cargoCompanyRepo;
        private ICargoDetailRepository _cargoDetailRepo;
        private ICargoOperationRepository _cargoOperationRepo;
        private ICargoCustomerRepository _cargoCustomerRepo;

        public RepositoryManager(CargoContext context, ICargoCompanyRepository cargoCompanyRepo, ICargoDetailRepository cargoDetailRepo, ICargoOperationRepository cargoOperationRepo, ICargoCustomerRepository cargoCustomerRepo)
        {
            _context = context;
            _cargoCompanyRepo = cargoCompanyRepo;
            _cargoDetailRepo = cargoDetailRepo;
            _cargoOperationRepo = cargoOperationRepo;
            _cargoCustomerRepo = cargoCustomerRepo;
        }

        public ICargoCompanyRepository CargoCompanyRepo => _cargoCompanyRepo;

        public ICargoDetailRepository CargoDetailRepo => _cargoDetailRepo;

        public ICargoOperationRepository CargoOperationRepo => _cargoOperationRepo;

        public ICargoCustomerRepository CargoCustomerRepo => _cargoCustomerRepo;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
