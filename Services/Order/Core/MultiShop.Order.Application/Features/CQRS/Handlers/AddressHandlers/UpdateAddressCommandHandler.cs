using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _addressRepository;
        public UpdateAddressCommandHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task Handle(UpdateAddressCommand updateAddressCommand)
        {
            var result = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);
            result.UserId = updateAddressCommand.UserId;
            result.District = updateAddressCommand.District;
            result.City = updateAddressCommand.City;
            result.Detail = updateAddressCommand.Detail;
            await _addressRepository.UpdateAsync(result);
        }
    }
}
