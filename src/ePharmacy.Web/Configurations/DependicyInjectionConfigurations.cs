using ePharmacy.Application.Dtos.AddressDtos;
using ePharmacy.Application.Mappings;
using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Application.Services.AddressService;
using ePharmacy.Application.Validators.AddressValidators;
using ePharmacy.Infrastructure.Persistence.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;


namespace ePharmacy.Web.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAddressRepository, AddressRepository>();
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IValidator<CreateAddressDto>, AddressCreateDtoValidator>();
        builder.Services.AddScoped<IValidator<UpdateAddressDto>, UpdateAddressDtoValidator>();

        builder.Services.AddScoped<ICardRepository, CardRepository>();
        builder.Services.AddScoped<ICardService, CardService>();


    }
}
♦