using AutoMapper;
using ePharmacy.Application.Dtos.AddressDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class AddressMapper : Profile
{
    public AddressMapper()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Address, CreateAddressDto>().ReverseMap();
        CreateMap<Address, UpdateAddressDto>().ReverseMap();
    }
}
