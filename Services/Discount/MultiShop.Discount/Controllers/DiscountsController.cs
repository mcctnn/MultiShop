using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDiscountCouponsAsync()
        {
            var coupons = await _discountService.GetCouponsAsync();
            return Ok(coupons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponByIdAsync(int id)
        {
            var coupon = await _discountService.GetCouponByIdAsync(id);
            if (coupon is null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCouponAsync(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla eklendi");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscountCouponAsync(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedDiscountCouponAsync(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi");
        }
    }
}
