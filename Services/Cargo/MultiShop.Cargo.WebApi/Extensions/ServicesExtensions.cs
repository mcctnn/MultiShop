using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.BusinessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.WebApi.ActionFilters;

namespace MultiShop.Cargo.WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CargoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services)=>services.AddScoped<IRepositoryManager,RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services)=> services.AddScoped<IServiceManager, ServiceManager>();
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

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();
        }
    }
}
