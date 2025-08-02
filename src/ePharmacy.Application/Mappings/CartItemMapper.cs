using AutoMapper;
using ePharmacy.Application.Dtos.CartDtos;

namespace ePharmacy.Application.Mappings;
public class CartItemMapper : Profile
{
    public CartItemMapper()
    {
        CreateMap<CartMapper, CartItemCreateDto>().ReverseMap();
    }
}
