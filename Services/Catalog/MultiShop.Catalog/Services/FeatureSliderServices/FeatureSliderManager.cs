using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderManager : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureDto)
        {
            var result = _mapper.Map<FeatureSlider>(createFeatureDto);
            await _featureSliderCollection.InsertOneAsync(result);
        }

        public async Task DeleteFeatureSliderAsync(string featureId)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderId == featureId);
        }

        public Task FeatureSliderStatusChangeToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderStatusChangeToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task<GetFeatureSliderByIdDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureSliderByIdDto>(value);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == updateFeatureDto.FeatureSliderId, value);
        }
    }
}
