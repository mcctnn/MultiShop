namespace MultiShop.Cargo.BusinessLayer.Abstract
{
    public interface IServiceManager
    {
        ICargoCompanyService CargoCompanyService { get; }
        ICargoCustomerService CargoCustomerService { get; }
        ICargoOperationService CargoOperationService { get; }
        ICargoDetailService CargoDetailService { get; }
    }
}
