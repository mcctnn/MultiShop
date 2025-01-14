using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.VendorDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.VendorServices
{
    public class VendorManager : IVendorService
    {
        private readonly IMongoCollection<Vendor> _vendorOfferCollection;
        private readonly IMapper _mapper;

        public VendorManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _vendorOfferCollection = database.GetCollection<Vendor>(databaseSettings.VendorCollectionName);
            _mapper = mapper;
        }
        public async Task CreateVendorAsync(CreateVendorDto createVendorDto)
        {
            var result = _mapper.Map<Vendor>(createVendorDto);
            await _vendorOfferCollection.InsertOneAsync(result);
        }

        public async Task DeleteVendorAsync(string vendorId)
        {
            await _vendorOfferCollection.DeleteOneAsync(x => x.VendorId == vendorId);
        }

        public async Task<List<ResultVendorDto>> GetAllVendorsAsync()
        {
            var values = await _vendorOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultVendorDto>>(values);
        }

        public async Task<GetVendorByIdDto> GetByIdVendorAsync(string id)
        {
            var result = await _vendorOfferCollection.Find<Vendor>(x => x.VendorId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetVendorByIdDto>(result);
        }

        public async Task UpdateVendorAsync(UpdateVendorDto updateVendorDto)
        {
            var result = _mapper.Map<Vendor>(updateVendorDto);
            await _vendorOfferCollection.FindOneAndReplaceAsync(x => x.VendorId == updateVendorDto.VendorId, result);
        }
    }
}
