using AutoMapper;
using ePharmacy.Application.Dtos.PaymentDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class PaymentMapper : Profile
{
    public PaymentMapper()
    {
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<Payment, CreatePaymentDto>().ReverseMap();
    }
}
