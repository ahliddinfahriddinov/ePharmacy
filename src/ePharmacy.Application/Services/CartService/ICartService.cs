using ePharmacy.Application.Dtos.CartDtos;

namespace ePharmacy.Application.Services.CartService;

public interface ICartService
{
    Task<long> AddItemToCartAsync(CartItemCreateDto cartItemCreateDto);
    Task ClearCartAsync(long userId);
    Task<CartDto> GetCartByUserIdAsync(long userId, bool withCartItems = false);
    Task RemoveCartAsync(long userId);
    Task UpdateCartAsync(long userId, CartDto cartDto);
}