using MultiShop.Catalog.Dtos.SocialMediaDtos;

namespace MultiShop.Catalog.Services.SocialMediaServices
{
    public interface ISocialMediaService
    {
        Task<List<ResultSocialMediaDto>> GetAllSocialMediasAsync();
        Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto);
        Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto);
        Task DeleteSocialMediaAsync(string categoryId);
        Task<GetSocialMediaByIdDto> GetByIdSocialMediaAsync(string id);
    }
}
