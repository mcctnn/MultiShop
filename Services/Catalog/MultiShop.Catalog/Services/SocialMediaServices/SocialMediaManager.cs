using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.SocialMediaDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SocialMediaServices
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly IMongoCollection<SocialMedia> _socialMediaCollection;
        private readonly IMapper _mapper;

        public SocialMediaManager(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _socialMediaCollection = database.GetCollection<SocialMedia>(databaseSettings.SocialMediaCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSocialMediaAsync(CreateSocialMediaDto createSocialMediaDto)
        {
            var result = _mapper.Map<SocialMedia>(createSocialMediaDto);
            await _socialMediaCollection.InsertOneAsync(result);
        }

        public async Task DeleteSocialMediaAsync(string socialMediaId)
        {
            await _socialMediaCollection.DeleteOneAsync(x => x.SocialMediaId == socialMediaId);
        }

        public async Task<List<ResultSocialMediaDto>> GetAllSocialMediasAsync()
        {
            var values = await _socialMediaCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSocialMediaDto>>(values);
        }

        public async Task<GetSocialMediaByIdDto> GetByIdSocialMediaAsync(string id)
        {
            var result = await _socialMediaCollection.Find<SocialMedia>(x => x.SocialMediaId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSocialMediaByIdDto>(result);
        }

        public async Task UpdateSocialMediaAsync(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var result = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            await _socialMediaCollection.FindOneAndReplaceAsync(x => x.SocialMediaId == updateSocialMediaDto.SocialMediaId, result);
        }
    }
}
