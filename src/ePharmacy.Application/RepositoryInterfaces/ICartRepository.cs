using ePharmacy.Domain.Entities;

namespace ePharmacy.Application.RepositoryInterfaces;
public interface ICartRepository
{
    Task<Cart> CreateCartAsync(long userId);
    Task ClearCartAsync(long userId);
    Task<Cart?> SelectCartByUserIdAsync(long userId, bool withCartItems = false);
    Task RemoveCartAsync(long userId);
    Task UpdateCartAsync(Cart cart);
    Task<int> SaveChangesAsync();
}