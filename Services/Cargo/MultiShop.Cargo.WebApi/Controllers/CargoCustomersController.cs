using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCustomerDto;
using MultiShop.Cargo.WebApi.ActionFilters;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CargoCustomersController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCustomerAsync(bool trackChanges)
        {
            var cargoCustomers = await _service.CargoCustomerService.GetCargoCustomersAsync(trackChanges);
            return Ok(cargoCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerByIdAsync(int id, bool trackChanges)
        {
            var cargoCustomer = await _service.CargoCustomerService.GetCargoCustomerByIdAsync(id, trackChanges);
            return Ok(cargoCustomer);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomerAsync(CargoCustomerDtoForInsertion cargoDto)
        {
            var cargoCustomer = await _service.CargoCustomerService.CreateOneCustomerAsync(cargoDto);
            return StatusCode(201, cargoCustomer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomerAsync(int id, CargoCustomerDtoForUpdate cargoDto)
        {
            await _service.CargoCustomerService.UpdateOneCustomerAsync(id, cargoDto, false);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomerAsync(int id)
        {
            await _service.CargoCustomerService.DeleteOneCustomerAsync(id, false);
            return Ok();
        }
    }
}
