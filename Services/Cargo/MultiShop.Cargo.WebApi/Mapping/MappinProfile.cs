using AutoMapper;
using MultiShop.Cargo.DtoLayer.CargoCompanyDto;
using MultiShop.Cargo.DtoLayer.CargoCustomerDto;
using MultiShop.Cargo.DtoLayer.CargoDetailDto;
using MultiShop.Cargo.DtoLayer.CargoOperationDto;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Mapping
{
    public class MappinProfile : Profile
    {
        public MappinProfile() {
            //cargo company
            CreateMap<CargoCompany,CargoCompanyDto>();
            CreateMap<CargoCompanyDtoForUpdate,CargoCompany>().ReverseMap();
            CreateMap<CargoCompanyDtoForInsertion, CargoCompany>().ReverseMap();

            //cargo customer
            CreateMap<CargoCustomer, CargoCustomerDto>();
            CreateMap<CargoCustomerDtoForUpdate, CargoCustomer>().ReverseMap();
            CreateMap<CargoCustomerDtoForInsertion, CargoCustomer>().ReverseMap();

            //cargo operation
            CreateMap<CargoOperation, CargoOperationDto>();
            CreateMap<CargoOperationDtoForUpdate, CargoOperation>().ReverseMap();
            CreateMap<CargoOperationDtoForInsertion, CargoOperation>().ReverseMap();

            //cargo detail
            CreateMap<CargoDetail, CargoDetailDto>();
            CreateMap<CargoDetailDtoForUpdate, CargoDetail>().ReverseMap();
            CreateMap<CargoDetailDtoForInsertion, CargoDetail>().ReverseMap();
        }
    }
}
