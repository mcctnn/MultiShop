using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var userId = _loginService.GetUserId;
            var basket = await _basketService.GetBasketTotalAsync(userId);
            return Ok(basket);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket([FromBody] BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Sepette değişiklikler kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var userId = _loginService.GetUserId;
            await _basketService.DeleteBasketAsync(userId);
            return Ok("Sepet silindi");
        }
    }
}
