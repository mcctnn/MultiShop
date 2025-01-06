using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Extensions
{
    public static class ServicesExtencions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();
            services.AddScoped<ICargoDetailService, CargoDetailManager>();
        }
        public static void ConfigureRepositoryServices(this IServiceCollection services) 
        { 
            services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
            services.AddScoped<ICargoCustomerRepository, CargoCustomerRepository>();
            services.AddScoped<ICargoOperationRepository, CargoOperationRepository>();
            services.AddScoped<ICargoDetailRepository, CargoDetailRepository>();
        }

    }
}
