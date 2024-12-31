using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;


namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageManager : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        public ProductImageManager(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        
        public async Task CreateProductImageAsync(CreateProductImageDto createProductDto)
        {
            var result = _mapper.Map<ProductImage>(createProductDto);
            await _productImageCollection.InsertOneAsync(result);
        }

        public async Task DeleteProductImageAsync(string productId)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImagesId == productId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var result =await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(result);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var result =await _productImageCollection.Find(x => x.ProductImagesId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(result);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductDto)
        {
            var result = _mapper.Map<ProductImage>(updateProductDto);
            await _productImageCollection.ReplaceOneAsync(x => x.ProductImagesId == updateProductDto.ProductImagesId, result);
        }
    }
}
