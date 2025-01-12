using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _SpecialOfferService;

        public SpecialOffersController(ISpecialOfferService SpecialOfferService)
        {
            _SpecialOfferService = SpecialOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialOffers()
        {
            var result = await _SpecialOfferService.GetAllSpecialOffersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSpecialOffer(string id)
        {
            var result = await _SpecialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _SpecialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return Ok("Özel fırsat eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSpecialOffer(string SpecialOfferId)
        {
            await _SpecialOfferService.DeleteSpecialOfferAsync(SpecialOfferId);
            return Ok("Özel fırsat silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return Ok("Özel fırsat güncellendi");
        }
    }
}
