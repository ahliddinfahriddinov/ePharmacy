using AutoMapper;
using ePharmacy.Application.Dtos.CartDtos;
using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using FluentValidation;

namespace ePharmacy.Application.Services.CartService;
public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IDrugRepository _drugRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CartItemCreateDto> _cartItemValidator;

    public CartService(
        ICartRepository cartRepository,
        IDrugRepository drugRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IValidator<CartItemCreateDto> cartItemValidator)
    {
        _cartRepository = cartRepository;
        _drugRepository = drugRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _cartItemValidator = cartItemValidator;
    }

    public async Task<long> AddItemToCartAsync(CartItemCreateDto cartItemCreateDto)
    {
        var validationResult = await _cartItemValidator.ValidateAsync(cartItemCreateDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var cart = await _cartRepository.SelectCartByUserIdAsync(cartItemCreateDto.UserId, true);
        if (cart == null)
        {
            cart = await _cartRepository.CreateCartAsync(cartItemCreateDto.UserId);
        }

        var user = await _userRepository.SelectByIdAsync(cart.UserId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        var drug = await _drugRepository.SelectByIdAsync(cartItemCreateDto.ProductId);
        if (drug == null)
        {
            throw new Exception("Drug not found");
        }

        var existingCartItem = cart.CartItems
            .FirstOrDefault(ci => ci.DrugId == cartItemCreateDto.ProductId);

        if (existingCartItem != null)
        {
            existingCartItem.Quantity += cartItemCreateDto.Quantity;
        }
        else
        {
            var newCartItem = _mapper.Map<CartItem>(cartItemCreateDto);
            newCartItem.CartId = cart.CartId;
            newCartItem.DrugId = drug.DrugId;
            newCartItem.Price = cartItemCreateDto.Price ?? 0;
            cart.CartItems.Add(newCartItem);
        }

        await _cartRepository.UpdateCartAsync(cart);
        await _cartRepository.SaveChangesAsync();
        return cart.CartId;
    }

    public async Task ClearCartAsync(long userId)
    {
        await _cartRepository.ClearCartAsync(userId);
    }

    public async Task<CartDto> GetCartByUserIdAsync(long userId, bool withCartItems = false)
    {
        var cart = await _cartRepository.SelectCartByUserIdAsync(userId, withCartItems);
        return _mapper.Map<CartDto>(cart);
    }

    public async Task RemoveCartAsync(long userId)
    {
        await _cartRepository.RemoveCartAsync(userId);
        await _cartRepository.SaveChangesAsync();
    }

    public async Task UpdateCartAsync(long userId, CartDto cartDto)
    {
        var existingCart = await _cartRepository.SelectCartByUserIdAsync(userId);
        _mapper.Map(cartDto, existingCart);
        await _cartRepository.UpdateCartAsync(existingCart);
        await _cartRepository.SaveChangesAsync();
        _mapper.Map<CartDto>(existingCart);
    }
}