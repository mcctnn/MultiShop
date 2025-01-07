using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoOperationDto;
using MultiShop.Cargo.WebApi.ActionFilters;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CargoOperationsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoOperationAsync(bool trackChanges)
        {
            var cargoOperations = await _service.CargoOperationService.GetCargoOperationsAsync(trackChanges);
            return Ok(cargoOperations);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationByIdAsync(int id, bool trackChanges)
        {
            var cargoOperation = await _service.CargoOperationService.GetCargoOperationByIdAsync(id,trackChanges);
            return Ok(cargoOperation);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperationAsync(CargoOperationDtoForInsertion cargoDto)
        {
            var cargoOperation=await _service.CargoOperationService.CreateOneOperationAsync(cargoDto);
            return StatusCode(201, cargoOperation);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperationAsync(int id,CargoOperationDtoForUpdate cargoDto)
        {
            await _service.CargoOperationService.UpdateOneOperationAsync(id, cargoDto, false);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOperationAsync(int id)
        {
            await _service.CargoOperationService.DeleteOneOperationAsync(id, false);
            return Ok();
        }
    }
}
