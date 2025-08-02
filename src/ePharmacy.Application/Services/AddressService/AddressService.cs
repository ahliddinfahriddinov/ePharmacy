using AutoMapper;
using ePharmacy.Application.Dtos.AddressDtos;
using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using FluentValidation;

namespace ePharmacy.Application.Services.AddressService;
public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateAddressDto> _createValidator;
    private readonly IValidator<UpdateAddressDto> _updateValidator;

    public AddressService(
        IAddressRepository addressRepository,
        IMapper mapper,
        IValidator<CreateAddressDto> createValidator,
        IValidator<UpdateAddressDto> updateValidator)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    public async Task<long> CreateAddressAsync(CreateAddressDto addressDto)
    {
        var validationResult = await _createValidator.ValidateAsync(addressDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var address = _mapper.Map<Address>(addressDto);
        await _addressRepository.InsertAsync(address);
        return address.AddressId;
    }

    public async Task<AddressDto> GetAddressByIdAsync(long id)
    {
        var address = await _addressRepository.SelectByIdAsync(id);
        return _mapper.Map<AddressDto>(address);
    }

    public async Task<ICollection<AddressDto>> GetAllAddressesAsync()
    {
        var addresses = await _addressRepository.SelectAllAsync();
        return _mapper.Map<ICollection<AddressDto>>(addresses);
    }

    public async Task<ICollection<AddressDto>> GetAddressesByUserIdAsync(long userId)
    {
        var addresses = await _addressRepository.SelectByUserIdAsync(userId);
        return _mapper.Map<ICollection<AddressDto>>(addresses);
    }

    public async Task UpdateAddressAsync(long id, UpdateAddressDto addressDto)
    {
        var validationResult = await _updateValidator.ValidateAsync(addressDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var existingAddress = await _addressRepository.SelectByIdAsync(id);

        _mapper.Map(addressDto, existingAddress);

        await _addressRepository.UpdateAsync(existingAddress);
    }

    public async Task DeleteAddressAsync(long id)
    {
        await _addressRepository.RemoveAsync(id);
    }
}
