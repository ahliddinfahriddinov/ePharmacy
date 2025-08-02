using AutoMapper;
using ePharmacy.Application.Dtos.OrderDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<Order, CreatePaymentDto>().ReverseMap();
    }
}