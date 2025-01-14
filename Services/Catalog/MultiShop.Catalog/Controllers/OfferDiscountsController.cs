using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController : ControllerBase
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountsController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOfferDiscounts()
        {
            var result = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOfferDiscount(string id)
        {
            var result = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return Ok("Kategoriye ait özel teklif eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfferDiscount(string OfferDiscountId)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(OfferDiscountId);
            return Ok("Kategoriye ait özel teklif silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return Ok("Kategoriye ait özel teklif güncellendi");
        }
    }
}
