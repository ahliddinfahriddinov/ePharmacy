using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;

    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task ClearCartAsync(long userId)
    {
        var cart = await SelectCartByUserIdAsync(userId, withCartItems: true);
        if (cart != null)
        {
            cart.CartItems.Clear();
            cart.TotalAmount = 0;
        }
    }

    public async Task<Cart> CreateCartAsync(long userId)
    {
        var cart = await SelectCartByUserIdAsync(userId);
        if (cart == null)
        {
            cart = new Cart
            {
                UserId = userId,
                TotalAmount = 0,
                IsActive = true,
                CartItems = new List<CartItem>()
            };
            _context.Carts.Add(cart);
        }
        return cart;
    }

    public async Task RemoveCartAsync(long userId)
    {
        var cart = await SelectCartByUserIdAsync(userId);
        if (cart != null)
        {
            _context.Carts.Remove(cart);
        }
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<Cart?> SelectCartByUserIdAsync(long userId, bool withCartItems = false)
    {
        var query = _context.Carts.AsQueryable();

        if (withCartItems)
        {
            query = query.Include(c => c.CartItems);
        }

        return await query.FirstOrDefaultAsync(c => c.UserId == userId && c.IsActive == true);
    }

    public async Task UpdateCartAsync(Cart cart)
    {
        var cartFromDB = await SelectCartByUserIdAsync(cart.UserId);
        if (cartFromDB != null)
        {
            _context.Carts.Update(cart);
        }
    }
}
