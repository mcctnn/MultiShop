using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketManager(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasketAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
            
        }

        public async Task<BasketTotalDto> GetBasketTotalAsync(string userId)
        {
            var existingBasket = await _redisService.GetDb().StringGetAsync(userId);
            
            return JsonSerializer.Deserialize<BasketTotalDto>(existingBasket);
        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
