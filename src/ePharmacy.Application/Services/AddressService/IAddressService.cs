using ePharmacy.Application.Dtos.AddressDtos;

namespace ePharmacy.Application.Services.AddressService;

public interface IAddressService
{
    Task<AddressDto> GetAddressByIdAsync(long id);
    Task<ICollection<AddressDto>> GetAllAddressesAsync();
    Task<ICollection<AddressDto>> GetAddressesByUserIdAsync(long userId);
    Task<long> CreateAddressAsync(CreateAddressDto addressDto);
    Task UpdateAddressAsync(long id, UpdateAddressDto addressDto);
    Task DeleteAddressAsync(long id);
}