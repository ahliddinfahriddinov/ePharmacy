using AutoMapper;
using ePharmacy.Application.Dtos.CardDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class CardMapper : Profile
{
    public CardMapper()
    {
        CreateMap<Card, CardDto>().ReverseMap();
        CreateMap<Card, CreateCardDto>().ReverseMap();
    }
}
