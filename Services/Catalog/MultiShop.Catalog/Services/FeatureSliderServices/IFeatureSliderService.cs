using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureDto);
        Task DeleteFeatureSliderAsync(string featureId);
        Task<GetFeatureSliderByIdDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderStatusChangeToTrue(string id);
        Task FeatureSliderStatusChangeToFalse(string id);
    }
}
