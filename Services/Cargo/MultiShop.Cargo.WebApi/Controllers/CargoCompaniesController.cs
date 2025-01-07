using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.CargoCompanyDto;
using MultiShop.Cargo.WebApi.ActionFilters;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public CargoCompaniesController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCompanyAsync(bool trackChanges)
        {
            var cargoCompanys = await _manager.CargoCompanyService.GetCargoCompaniesAsync(trackChanges);
            return Ok(cargoCompanys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyByIdAsync(int id, bool trackChanges)
        {
            var cargoCompany = await _manager.CargoCompanyService.GetCargoCompanyByIdAsync(id, trackChanges);
            return Ok(cargoCompany);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompanyAsync(CargoCompanyDtoForInsertion cargoDto)
        {
            var cargoCompany = await _manager.CargoCompanyService.CreateOneCompanyAsync(cargoDto);
            return StatusCode(201, cargoCompany);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompanyAsync(int id, CargoCompanyDtoForUpdate cargoDto)
        {
            await _manager.CargoCompanyService.UpdateOneCompanyAsync(id, cargoDto, false);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCompanyAsync(int id)
        {
            await _manager.CargoCompanyService.DeleteOneCompanyAsync(id, false);
            return Ok();
        }

    }
}
