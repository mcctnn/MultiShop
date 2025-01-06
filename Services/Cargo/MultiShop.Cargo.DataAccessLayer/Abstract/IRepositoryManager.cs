namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
    public interface IRepositoryManager
    {
        ICargoCompanyRepository CargoCompanyRepo { get; }
        ICargoDetailRepository CargoDetailRepo { get; }
        ICargoOperationRepository CargoOperationRepo { get; }
        ICargoCustomerRepository CargoCustomerRepo { get; }
        Task SaveAsync();
    }
}
