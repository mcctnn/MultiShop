using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Services.VendorServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendors()
        {
            var result = await _vendorService.GetAllVendorsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdVendor(string id)
        {
            var result = await _vendorService.GetByIdVendorAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVendor(CreateVendorDto createVendorDto)
        {
            await _vendorService.CreateVendorAsync(createVendorDto);
            return Ok("Satıcı marka  eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVendor(string VendorId)
        {
            await _vendorService.DeleteVendorAsync(VendorId);
            return Ok("Satıcı marka  silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVendor(UpdateVendorDto updateVendorDto)
        {
            await _vendorService.UpdateVendorAsync(updateVendorDto);
            return Ok("Satıcı marka  güncellendi");
        }
    }
}
