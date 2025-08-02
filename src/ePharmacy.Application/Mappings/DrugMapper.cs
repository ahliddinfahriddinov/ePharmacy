using AutoMapper;
using ePharmacy.Application.Dtos.DrugDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class DrugMapper : Profile
{
    public DrugMapper()
    {
        CreateMap<Drug, DrugDto>().ReverseMap();
        CreateMap<Drug, CreateDrugDto>().ReverseMap();
    }
}
