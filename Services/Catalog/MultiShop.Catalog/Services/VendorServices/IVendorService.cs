using MultiShop.Catalog.Dtos.VendorDtos;

namespace MultiShop.Catalog.Services.VendorServices
{
    public interface IVendorService
    {
        Task<List<ResultVendorDto>> GetAllVendorsAsync();
        Task CreateVendorAsync(CreateVendorDto createVendorDto);
        Task UpdateVendorAsync(UpdateVendorDto updateVendorDto);
        Task DeleteVendorAsync(string vendorId);
        Task<GetVendorByIdDto> GetByIdVendorAsync(string id);
    }
}
