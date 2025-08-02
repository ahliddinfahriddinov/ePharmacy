using AutoMapper;
using ePharmacy.Application.Dtos.CartDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class CartMapper : Profile
{
    public CartMapper()
    {
        CreateMap<Cart, CartDto>().ReverseMap();
        CreateMap<Cart, CreateCartDto>().ReverseMap();
    }
}
