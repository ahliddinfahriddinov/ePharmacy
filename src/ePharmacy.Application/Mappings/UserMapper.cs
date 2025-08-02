using AutoMapper;
using ePharmacy.Application.Dtos.UserDtos;
using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.Mappings;
public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();
    }
}