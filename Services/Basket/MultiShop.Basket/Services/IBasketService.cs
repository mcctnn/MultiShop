using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotalAsync(string userId);
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);
    }
}
