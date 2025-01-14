using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountManager : IOfferDiscountService
    {
        private readonly IMongoCollection<OfferDiscount> _offerDiscountCollection;
        private readonly IMapper _mapper;

        public OfferDiscountManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public  async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var result = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountCollection.InsertOneAsync(result);
        }

        public async Task DeleteOfferDiscountAsync(string offerDiscountId)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.OfferDiscountId == offerDiscountId);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<GetOfferDiscountByIdDto> GetByIdOfferDiscountAsync(string id)
        {
            var result = await _offerDiscountCollection.Find<OfferDiscount>(x => x.OfferDiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetOfferDiscountByIdDto>(result);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var result = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.OfferDiscountId == updateOfferDiscountDto.OfferDiscountId, result);
        }
    }
}
