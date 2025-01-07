using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoDetailDto;
using MultiShop.Cargo.WebApi.ActionFilters;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CargoDetailsController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoDetailsAsync(bool trackChanges)
        {
            var cargoDetails = await _service.CargoDetailService.GetAllCargoDetailsAsync(trackChanges);
            return Ok(cargoDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailByIdAsync(int id, bool trackChanges)
        {
            var cargoDetail = await _service.CargoDetailService.GetCargoDetailByIdAsync(id, trackChanges);
            return Ok(cargoDetail);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetailAsync(CargoDetailDtoForInsertion cargoDto)
        {
            var cargoDetail = await _service.CargoDetailService.CreateOneDetailAsync(cargoDto);
            return StatusCode(201, cargoDetail);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCargoDetailAsync(int id, CargoDetailDtoForUpdate cargoDto)
        {
            await _service.CargoDetailService.UpdateOneDetailAsync(id, cargoDto, false);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoDetailAsync(int id)
        {
            await _service.CargoDetailService.DeleteOneDetailAsync(id, false);
            return Ok();
        }
    }
}
