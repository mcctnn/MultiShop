using MultiShop.Cargo.BusinessLayer.Abstract;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly ICargoOperationService _cargoOperationService;
        private readonly ICargoDetailService _cargoDetailService;

        public ServiceManager(ICargoCompanyService cargoCompanyService, ICargoCustomerService cargoCustomerService, ICargoOperationService cargoOperationService, ICargoDetailService cargoDetailService)
        {
            _cargoCompanyService = cargoCompanyService;
            _cargoCustomerService = cargoCustomerService;
            _cargoOperationService = cargoOperationService;
            _cargoDetailService = cargoDetailService;
        }

        public ICargoCompanyService CargoCompanyService => _cargoCompanyService;

        public ICargoCustomerService CargoCustomerService => _cargoCustomerService;

        public ICargoOperationService CargoOperationService => _cargoOperationService;

        public ICargoDetailService CargoDetailService => _cargoDetailService;
    }
}
