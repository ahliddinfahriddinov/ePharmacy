using AutoMapper;
using ePharmacy.Application.Dtos.PharmacyDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class PharmacyMapper : Profile
{
    public PharmacyMapper()
    {
        CreateMap<Pharmacy, PharmacyDto>().ReverseMap();
        CreateMap<Pharmacy, CreatePharmacyDto>().ReverseMap();
    }
}