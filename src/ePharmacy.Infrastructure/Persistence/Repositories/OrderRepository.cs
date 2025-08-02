using ePharmacy.Application.RepositoryInterfaces;
using ePharmacy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ePharmacy.Infrastructure.Persistence.Repositories;
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<long> InsertAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order.OrderId;
    }

    public async Task RemoveAsync(long id)
    {
        var order = await SelectByIdAsync(id);
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Order>> SelectAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> SelectByIdAsync(long id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        if (order == null)
        {
            throw new KeyNotFoundException($"Order with ID {id} not found.");
        }
        return order;
    }

    public async Task<ICollection<Order>> SelectByUserIdAsync(long userId)
    {
        return await _context.Orders
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task<ICollection<Order>> SelectByPharmacyIdAsync(long pharmacyId)
    {
        return await _context.Orders
            .Where(o => o.PharmacyId == pharmacyId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
