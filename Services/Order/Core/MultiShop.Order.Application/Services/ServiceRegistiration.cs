using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

namespace MultiShop.Order.Application.Services
{
    public static class ServiceRegistration
    {
        public static void AddOrderingApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(c=>c.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        }
        public static void ConfigureAddressServices(this IServiceCollection services)
        {
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();
        }
        public static void ConfigureOrderDetailServices(this IServiceCollection services)
        {
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
        }
    }
}
