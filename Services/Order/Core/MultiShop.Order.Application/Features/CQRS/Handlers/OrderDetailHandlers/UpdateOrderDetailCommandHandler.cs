using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand )
        {
            var result=await _orderDetailRepository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            result.ProductId = updateOrderDetailCommand.ProductId;
            result.ProductName = updateOrderDetailCommand.ProductName;
            result.ProductPrice = updateOrderDetailCommand.ProductPrice;
            result.ProductAmount = updateOrderDetailCommand.ProductAmount;
            result.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            result.OrderingId = updateOrderDetailCommand.OrderingId;
            await _orderDetailRepository.UpdateAsync(result);
        }
    }
}
