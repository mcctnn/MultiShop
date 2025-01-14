using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public class FeatureManager : IFeatureService
    {
        private readonly IMongoCollection<Feature> _FeatureCollection;
        private readonly IMapper _mapper;

        public FeatureManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _FeatureCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var result = _mapper.Map<Feature>(createFeatureDto);
            await _FeatureCollection.InsertOneAsync(result);
        }

        public async Task DeleteFeatureAsync(string FeatureId)
        {
            await _FeatureCollection.DeleteOneAsync(x => x.FeatureId == FeatureId);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            var values = await _FeatureCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetFeatureByIdDto> GetByIdFeatureAsync(string id)
        {
            var result = await _FeatureCollection.Find<Feature>(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFeatureByIdDto>(result);
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var result = _mapper.Map<Feature>(updateFeatureDto);
            await _FeatureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, result);
        }
    }
}
